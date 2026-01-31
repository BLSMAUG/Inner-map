using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedWalk;

    CharacterController Cac;

    [SerializeField]
    private AudioClip footstepConcreteLoopClip;

    [SerializeField]
    private AudioClip footstepHerbeLoopClip;

    [SerializeField]
    private AudioClip footstepStoneLoopClip;

    private bool isFootstepPlaying;

    private bool isTryingToMove;

    public PlayerRaycast playerRaycast;

    void Start()
    {
        Cac = GetComponent<CharacterController>();

        //rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        Move();
        HandleFootsteps();
        //TestSol();
        //OnCollisionEnter();

    }

    void Move()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ += 1f;
        if (Input.GetKey(KeyCode.S)) moveZ -= 1f;
        if (Input.GetKey(KeyCode.A)) moveX -= 1f;
        if (Input.GetKey(KeyCode.D)) moveX += 1f;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        isTryingToMove = move.sqrMagnitude > 0.01f;

        move = Vector3.ClampMagnitude(move, 1f);

        Cac.Move(move * speedWalk * Time.deltaTime);

    }

    //script Yaniss
    void HandleFootsteps()
    {
        if (AudioManager.instance == null || footstepConcreteLoopClip == null)
        {
            return;
        }

        if (isTryingToMove && playerRaycast.isOnConcrete == true)
        {
            AudioManager.instance.PlayLoopSFX(footstepConcreteLoopClip);
            isFootstepPlaying = true;
            //Debug.Log("Play");
        }

        else if (isTryingToMove && playerRaycast.isOnHerbe == true)
        {
            AudioManager.instance.PlayLoopSFX(footstepHerbeLoopClip);
            isFootstepPlaying = true;
        }

        else if (isTryingToMove && playerRaycast.isOnStone == true)
        {
            AudioManager.instance.PlayLoopSFX(footstepStoneLoopClip);
            isFootstepPlaying = true;
        }
        else
        {
            if (!isTryingToMove)
            {
                AudioManager.instance.StopLoopSFX();
                isFootstepPlaying = false;
                //Debug.Log("stop");
            }
        }
    }

}
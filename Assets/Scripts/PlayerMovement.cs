using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedWalk;

    CharacterController Cac;

    [SerializeField]
    private AudioClip footstepLoopClip;

    private bool isFootstepPlaying;

    private bool isTryingToMove;

    void Start()
    {
        Cac = GetComponent<CharacterController>();
        
    }


    void Update()
    {
        Move();
        HandleFootsteps();
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

    void HandleFootsteps()
    {
        if (AudioManager.instance == null || footstepLoopClip == null)
        {
            return;
        }

        if (isTryingToMove && Cac.isGrounded)
        {
            if (!isFootstepPlaying)
            {
                AudioManager.instance.PlayLoopSFX(footstepLoopClip);
                isFootstepPlaying = true;
            }
        }
        else
        {
            if (isFootstepPlaying)
            {
                AudioManager.instance.StopLoopSFX();
                isFootstepPlaying = false;
            }
        }
    }

}
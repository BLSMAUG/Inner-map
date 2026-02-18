
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

    [SerializeField]
    private AudioClip footstepWoodLoopClip;

    //[SerializeField]
    //private AudioClip footstepSound;

    //public enum GroundType
    //{
    //    //None,
    //    Herbe,
    //    Concrete,

    //    Stone,
    //    Wood
    //}

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

        //if (AudioManager.instance == null)
        //{
        //    return;
        //}

        //AudioClip clipToPlay = null;

        //if (isTryingToMove)
        //{
        //    if (playerRaycast.isOnConcrete)
        //    {
        //        clipToPlay = footstepConcreteLoopClip;
        //    }
        //    else if (playerRaycast.isOnHerbe)
        //    {
        //        clipToPlay = footstepHerbeLoopClip;
        //    }
        //    else if (playerRaycast.isOnStone)
        //    {
        //        clipToPlay = footstepStoneLoopClip;
        //    }
        //    else if (playerRaycast.isOnWood)
        //    {
        //        clipToPlay = footstepWoodLoopClip;
        //    }
        //}

        //if (clipToPlay != null)
        //{
        //    if (!isFootstepPlaying)
        //    {
        //        AudioManager.instance.PlayLoopSFX(clipToPlay);
        //        isFootstepPlaying = true;
        //        Debug.Log("SON MARCHE");
        //    }

        //}

        //else
        //{
        //    if (isFootstepPlaying)
        //    {
        //        AudioManager.instance.StopLoopSFX();
        //        isFootstepPlaying= false;
        //        Debug.Log("SON MARCHE PAS");
        //    }
        //}

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

        else if (isTryingToMove && playerRaycast.isOnWood == true)
        {
            AudioManager.instance.PlayLoopSFX(footstepWoodLoopClip);
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

        //if (AudioManager.instance == null || !isTryingToMove)
        //{
        //    AudioManager.instance.StopLoopSFX();
        //    isFootstepPlaying = false;
        //    return;
        //}

        //AudioClip clipToPlay = null;


        //switch (PlayerRaycast.currentGround)
        //{
        //    case GroundType.Concrete:
        //        Debug.Log(clipToPlay);
        //        clipToPlay = footstepConcreteLoopClip;
        //        break;

        //    case GroundType.Herbe:
        //        clipToPlay = footstepHerbeLoopClip;
        //        break;

        //    case GroundType.Stone:
        //        clipToPlay = footstepStoneLoopClip;
        //        break;

        //    case GroundType.Wood:
        //        clipToPlay = footstepWoodLoopClip;
        //        break;
        //}

        //if (clipToPlay != null)
        //{
        //    AudioManager.instance.PlayLoopSFX(clipToPlay);
        //    isFootstepPlaying = true;
        //}

        //switch (footstepSound)
        //{
        //    case 1:
        //        if (isTryingToMove && playerRaycast.isOnConcrete == true)
        //        {
        //            footstepSound = footstepConcreteLoopClip;
        //            AudioManager.instance.PlayLoopSFX(footstepSound);
        //            isFootstepPlaying = true;
        //            break;
        //        }

        //    case 2:
        //        if (isTryingToMove && playerRaycast.isOnHerbe == true)
        //        {
        //            footstepSound = footstepHerbeLoopClip;
        //            AudioManager.instance.PlayLoopSFX(footstepSound);
        //            isFootstepPlaying = true;
        //            break;
        //        }

        //    case 3:
        //        if (isTryingToMove && playerRaycast.isOnStone == true)
        //        {
        //            footstepSound = footstepStoneLoopClip;
        //            AudioManager.instance.PlayLoopSFX(footstepSound);
        //            isFootstepPlaying = true;
        //            break;
        //        }

        //    case 4:
        //        if (isTryingToMove && playerRaycast.isOnWood == true)
        //        {
        //            footstepSound = footstepWoodLoopClip;
        //            AudioManager.instance.PlayLoopSFX(footstepSound);
        //            isFootstepPlaying = true;
        //            break;
        //        }

        //    default:
        //        break;

        //}


    }

}
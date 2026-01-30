using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speedWalk;


    CharacterController Cac;


    void Start()
    {
        Cac = GetComponent<CharacterController>();
    }


    void Update()
    {
        Move();
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

        move = Vector3.ClampMagnitude(move, 1f);

        Cac.Move(move * speedWalk * Time.deltaTime);

    }
}
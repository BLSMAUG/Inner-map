using UnityEngine;
using System.Collections.Generic;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;

    bool isInGame = true;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   

    }


    void Update()
    {

        CameraMovement();
        TestCameraMode();

    }

    public void CameraMovement()
    {
        if (isInGame == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            player.Rotate(Vector3.up * inputX);
        }
        else
        {
            Cursor.lockState= CursorLockMode.Confined;
        }
    }

    public void TestCameraMode()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            isInGame = !isInGame;
        }
    }
    
}

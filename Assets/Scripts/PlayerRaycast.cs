using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float playerReach;
    void Start()
    {

    }

    
    void Update()
    {
        Raycast();
    }

    
    public void Raycast()
    {
        RaycastHit hitInfo;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Doing ray test");
            if (Physics.Raycast(camRay, out hitInfo, playerReach))
            {
                Debug.Log("Hit something: " + hitInfo.transform.tag);
                if (hitInfo.transform.tag == "Objet")
                {
                    Debug.Log("Hit the object");
                }
            }
        }
    }

}

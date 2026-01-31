using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float playerReach;
    public string hitName;
    public string hitObjectName;
    public Inventaire inventaire;

    [SerializeField]
    public bool isOnConcrete;

    [SerializeField]
    public bool isOnHerbe;

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
                    hitObjectName = hitInfo.collider.gameObject.name;
                    ClassItem hitObject = hitInfo.collider.gameObject.GetComponent<ClassItem>();
                    hitName = hitObject.itemName;
                    if (hitObject.isReachable == true)
                    {
                        Debug.Log(hitName);
                        Destroy(GameObject.Find(hitObjectName));
                        inventaire.AddToInventory(hitName);

                    }
                    
                }
            }
        }

        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1.5f))
        {
            if (hitInfo.collider.CompareTag("Concrete"))
            {
                Debug.Log("Concrete");
                isOnConcrete = true;
            }

            else if (hitInfo.collider.CompareTag("Herbe"))
            {
                Debug.Log("Herbe");
                isOnHerbe = true;
            }
        }
    }

}

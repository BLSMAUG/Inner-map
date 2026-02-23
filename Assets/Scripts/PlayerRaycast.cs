
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public float playerReach;
    public string hitName;
    public string hitObjectName;
    public Inventaire inventaire;
    public GameManager gameManager;

    static public bool eKeyState = false;
    static public bool fKeyState = false;

    //static public PlayerMovement.GroundType currentGround;

    //[SerializeField] 
    //private float groundRayLength = 2f;

    //[SerializeField] 
    //private LayerMask groundLayer;

    public GameObject fusible;
    public bool isOnConcrete;

    public bool isOnHerbe;

    public bool isOnStone;

    public bool isOnWood;
    public GameObject emplacementFusible;
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        //UpdateGround();
        Raycast();
        InterractionDialogue();
        InterractKey();
        PickUpKey();
        PorteInteraction();
        FusibleGenerateur();
    }

    //void FixedUpdate()
    //{
    //    Raycast();
    //}
    // if (hitInfo.transform.tag == "Generateur" && fusible.GetComponent<ClassItem>().isInInventory==true)
    // {
    //     GameObject fusiblePlaced = Instantiate(fusible);
    //     fusiblePlaced.GetComponent<RectTransform>().anchoredPosition = emplacementFusible.GetComponent<RectTransform>().anchoredPosition;
    //     inventaire.DeleteFromInventory(fusible.GetComponent<ClassItem>());
    // }

    public void PorteInteraction()
    {
        RaycastHit hitInfo;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out hitInfo, playerReach))
        {
            if (hitInfo.transform.tag == "Objet")
            {
                hitObjectName = hitInfo.collider.gameObject.name;
                ClassItem hitObject = hitInfo.collider.gameObject.GetComponent<ClassItem>();
                hitName = hitObject.itemName;
                if (hitObject.isReachable == true && hitName=="Porte")
                {
                    // Debug.Log(hitName);
                    //GameManager.porteSalle1 = hitName;
                    GameManager.OverturePorte(hitInfo.collider.gameObject);
                }
                if (hitObject.isReachable == true && hitName=="Portedouble")
                {
                    // Debug.Log(hitName);
                    //GameManager.porteSalle1 = hitName;
                    GameManager.OverturePorteDouble(hitInfo.collider.gameObject);
                }
            }
        }
        
    }
    
    public void FusibleGenerateur()
    {
        RaycastHit hitInfo;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out hitInfo, playerReach))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hitInfo.transform.tag == "Generateur" && fusible.GetComponent<ClassItem>().isInInventory==true)
                {
                    Debug.Log("YES CA LARCGHE");
                    GameObject fusiblePlaced = Instantiate(fusible);
                    fusiblePlaced.GetComponent<Transform>().position = emplacementFusible.GetComponent<Transform>().position;
                    inventaire.DeleteFromInventory(fusible.GetComponent<ClassItem>());
                }
            }
        }
        
    }

    public void Raycast()
    {
        RaycastHit hitInfo;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.F))
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
                    if (hitObject.itemName == "Fusible")
                    {
                        Debug.Log(hitName);
                        if (gameManager.epuisette.isInInventory==true)
                        {
                            inventaire.DeleteFromInventory(gameManager.epuisette);
                            Destroy(GameObject.Find(hitObjectName));
                            inventaire.AddToInventory(hitObject.itemName);  
                        }

                        // GameManager.TakeFusible(hitObject);
                        // Destroy(GameObject.Find(hitObjectName));
                    }
                    else if (hitObject.isReachable == true && hitObject.isCollectible==true&& hitObject.itemName != "Fusible")
                    {
                        if (hitObject.itemDescription == "Cle")
                        {
                            gameManager.cle = hitObject;
                        }
                        Debug.Log(hitName);
                        Destroy(GameObject.Find(hitObjectName));
                        inventaire.AddToInventory(hitName);
                        
                    }
                }
            }
        }



        isOnConcrete = false;
        isOnHerbe = false;
        isOnStone = false;
        isOnWood = false;

        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 25f))
        {
            if (hitInfo.collider.CompareTag("Concrete"))
            {
                //Debug.Log("Concrete");
                isOnConcrete = true;
                //currentGround = PlayerMovement.GroundType.Concrete;
            }

            else if (hitInfo.collider.CompareTag("Herbe"))
            {
                // Debug.Log("Herbe");
                isOnHerbe = true;
                //currentGround = PlayerMovement.GroundType.Herbe;
            }

            else if (hitInfo.collider.CompareTag("Stone"))
            {
                // Debug.Log("Stone");
                isOnStone = true;
                //currentGround = PlayerMovement.GroundType.Stone;
            }

            else if (hitInfo.collider.CompareTag("Wood"))
            {
                // Debug.Log("Stone");
                isOnWood = true;
                //currentGround = PlayerMovement.GroundType.Wood;
            }
        }

    }

    public void InterractionDialogue()
    {
        RaycastHit hitInfo;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(camRay, out hitInfo, playerReach))
        {
            if (hitInfo.transform.tag == "Objet")
            {
                hitObjectName = hitInfo.collider.gameObject.name;
                ClassItem hitObject = hitInfo.collider.gameObject.GetComponent<ClassItem>();
                hitName = hitObject.itemName;
                while (hitObject.isReachable == true)
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Dialogues.currentDialogue = ClassItem.hitIndex;
                        //Debug.Log(Dialogues.currentDialogue);
                        Dialogues.isInDialogue = true;
                        //Dialogues.Dialogue(0);

                    }
                    break;
                }
            }
        }
    }

    public void InterractKey()
    {
        RaycastHit hitInfo;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out hitInfo, playerReach))
        {
            if (hitInfo.transform.tag == "Objet")
            {
                eKeyState = true;
            }
            else
            {
                eKeyState = false;
            }
        }
        else
        {
            eKeyState = false;
        }
    }

    public void PickUpKey()
    {
        RaycastHit hitInfo;
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out hitInfo, playerReach))
        {
            if (hitInfo.transform.tag == "Objet")
            {
                hitObjectName = hitInfo.collider.gameObject.name;
                ClassItem hitObject = hitInfo.collider.gameObject.GetComponent<ClassItem>();
                if (hitObject.isCollectible == true)
                {
                    fKeyState = true;
                }
                else
                {
                    fKeyState = false;
                }
            }
        }
        else
        {
            fKeyState = false;
        }
    }

    //void UpdateGround()
    //{
    //    // Reset
    //    isOnConcrete = false;
    //    isOnHerbe = false;
    //    isOnStone = false;
    //    isOnWood = false;

    //    RaycastHit hit;
    //    Vector3 origin = transform.position + Vector3.up * 0.2f;

    //    if (Physics.Raycast(origin, Vector3.down, out hit, groundRayLength, groundLayer))
    //    {
    //        switch (hit.collider.tag)
    //        {
    //            case "Concrete":
    //                isOnConcrete = true;
    //                break;

    //            case "Herbe":
    //                isOnHerbe = true;
    //                break;

    //            case "Stone":
    //                isOnStone = true;
    //                break;

    //            case "Wood":
    //                isOnWood = true;
    //                break;
    //        }
    //    }
    //}

}

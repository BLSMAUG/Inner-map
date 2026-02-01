using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerRaycast : MonoBehaviour
{
    public float playerReach;
    public string hitName;
    public string hitObjectName;
    public Inventaire inventaire;

    static public bool eKeyState = false;
    static public bool fKeyState = false;

    //static public PlayerMovement.GroundType currentGround;

    //[SerializeField] 
    //private float groundRayLength = 2f;

    //[SerializeField] 
    //private LayerMask groundLayer;


    public bool isOnConcrete;

    public bool isOnHerbe;

    public bool isOnStone;

    public bool isOnWood;

    void Start()
    {

    }


    void Update()
    {
        //UpdateGround();
        Raycast();
        //InterractionDialogue();
        InterractKey();
        PickUpKey();
    }

    //void FixedUpdate()
    //{
    //    Raycast();
    //}


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
                    if (hitObject.isReachable == true && hitObject.isCollectible==true)
                    {
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
                Debug.Log("Herbe");
                isOnHerbe = true;
                //currentGround = PlayerMovement.GroundType.Herbe;
            }

            else if (hitInfo.collider.CompareTag("Stone"))
            {
                Debug.Log("Stone");
                isOnStone = true;
                //currentGround = PlayerMovement.GroundType.Stone;
            }

            else if (hitInfo.collider.CompareTag("Wood"))
            {
                Debug.Log("Stone");
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

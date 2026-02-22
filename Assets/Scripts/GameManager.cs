
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField]
    static public GameObject porteSalle1;
    [SerializeField]
    static public GameObject porte1Salle2;
    [SerializeField]
    static public GameObject porte2Salle2;
    // static public bool porte1isOpened=false;
    // static public bool porte2isOpened=false;
    static public Transform tInventory;
    static public Inventaire canva;
    [SerializeField]
    public ClassItem cle;
    static public AudioSource DoorAndKey;
    [SerializeField]
    public static ClassItem epuisette;

    public GameState currentState;

    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        Dialogue
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }

        // else
        // {
        //     Destroy(gameObject);
        //     return;
        // }
    }
    
    void Start()
    {
        SetState(GameState.Playing);
        //porteSalle1=GameObject.Find("Salle1Porte2");
        cle = GameObject.Find("Cle1").GetComponent<ClassItem>();
        canva = GameObject.Find("Canvas").GetComponent<Inventaire>();
        DoorAndKey=GameObject.Find("DoorAndKey").GetComponent<AudioSource>();
        Debug.Log(canva);
        epuisette= GameObject.Find("Epuisette").GetComponent<ClassItem>();
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.Menu:
                Time.timeScale = 0f;
                break;

            case GameState.Playing:
                Time.timeScale = 1f;
                break;

            case GameState.Paused:
                Time.timeScale = 0f;
                break;
        }

    }

    // static public void OverturePorte(ClassItem cle, GameObject porte)
    // {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         Debug.Log("E pressed");
    //         if (cle.isInInventory)
    //         {
    //             Debug.Log("Yalakl�");
    //             canva.DeleteFromInventory(cle);
    //             porte.transform.Rotate(0, 90, 0);
    //             ClassItem pI = porte.GetComponent<ClassItem>();
    //             pI.isInInventory = true;
    //             DoorAndKey.Play();
    //         }
    //     }
    // }

    static public void OverturePorte(GameObject porte)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            foreach (ClassItem element in Inventaire.inventaire)
            {
                //Debug.Log(element);
                if (element.itemDescription == "Cle")
                {
                    canva.DeleteFromInventory(element);
                    Debug.Log("Yalakl�");
                    porte.transform.Rotate(0, 90, 0);
                    ClassItem pI = porte.GetComponent<ClassItem>();
                    pI.isInInventory = true;
                    DoorAndKey.Play();
                    break;
                }
            }
        }
    }

    static public void OverturePorteDouble(GameObject porte)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ClassItem pI = porte.GetComponent<ClassItem>();
            GameObject porte1 = porte.transform.GetChild(0).gameObject;
            GameObject porte2 = porte.transform.GetChild(1).gameObject;;
            if (pI.isInInventory == false)
            {
                //Debug.Log("Yalakl�");
                porte1.transform.Rotate(0, -90, 0);
                porte2.transform.Rotate(0, 90, 0);
                pI.isInInventory = true;
                DoorAndKey.Play();
                // BoxCollider bc = porte.GetComponent<BoxCollider>();
                // Debug.Log(bc);
                // Debug.Log(bc.isTrigger);
                // bc.isTrigger = true;
                // bc.enabled =false;
                // Debug.Log(bc.isTrigger);
            }
        }
    }

    public bool CanPlayerMove()
    {
        return currentState == GameState.Playing;
    }

    static public void TakeFusible(ClassItem fusible)
    {
        if (epuisette.isInInventory==true)
        {
            canva.AddToInventory(fusible.itemName);
            canva.DeleteFromInventory(epuisette);
        }
        else
        {
            //en vrai jsp si on fait ca avec le strucs de dialogue mais je mets �a au cas o�
        }
    }


    // Update is called once per frame
    void Update()
    {
        //OverturePorte(cle, porteSalle1);
    }
}

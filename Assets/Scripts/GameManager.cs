using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    static public GameObject porteSalle1;
    static public GameObject porte1Salle2;
    static public GameObject porte2Salle2;
    static public bool porte1isOpened=false;
    static public bool porte2isOpened=false;
    static public Transform tInventory;
    static public Inventaire canva;
    static public ClassItem cle;
    static public AudioSource DoorAndKey;
    public ClassItem epuisette;

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
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    void Start()
    {
        SetState(GameState.Playing);
        porteSalle1=GameObject.Find("Porte");
        cle = GameObject.Find("props_cle").GetComponent<ClassItem>();
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

    static public void OverturePorte(ClassItem cle, GameObject porte)
    {
        if (Input.GetKeyDown(KeyCode.E))
        { 
            if (GameManager.porte1isOpened == false)
            {
                if (cle.isInInventory == true)
                {
                    //Debug.Log("Yalaklé");
                    porte.transform.Rotate(0, 90, 0);
                    porte1isOpened = true;
                    DoorAndKey.Play();
                    canva.inventaire.Remove(cle);
                    cle.isInInventory = false;
                    Destroy(tInventory.GetChild(9).gameObject);
                }
            }
        }
    }

    public void OverturePorteDouble(GameObject porte1, GameObject porte2)
    {
        if (porte1isOpened == false)
        {
            //Debug.Log("Yalaklé");
            porte1.transform.Rotate(0, 90, 0);
            porte2.transform.Rotate(0, 90, 0);
            porte1isOpened = true;
            DoorAndKey.Play();
        }
    }

    public bool CanPlayerMove()
    {
        return currentState == GameState.Playing;
    }

    public void TakeFusible(ClassItem fusible)
    {
        if (epuisette.isInInventory==true)
        {
            canva.AddToInventory(fusible.itemName);
            canva.DeleteFromInventory(epuisette);
        }
        else
        {
            //en vrai jsp si on fait ca avec le strucs de dialogue mais je mets ça au cas où
        }
    }


    // Update is called once per frame
    void Update()
    {
        //OverturePorte(cle, porteSalle1);
    }
}

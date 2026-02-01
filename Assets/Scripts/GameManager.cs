using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject porteSalle1;
    public GameObject porte1Salle2;
    public GameObject porte2Salle2;
    public bool porte1isOpened=false;
    public bool porte2isOpened=false;
    public Transform tInventory;
    [SerializeField]
    public Inventaire canva;
    public ClassItem cle;
    [SerializeField]
    public AudioSource DoorAndKey;
    [SerializeField]
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

    public void OverturePorte(ClassItem cle, GameObject porte)
    {
        if (porte1isOpened == false)
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
        OverturePorte(cle, porteSalle1);
    }
}

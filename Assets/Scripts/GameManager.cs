using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject porteSalle1;
    public GameObject porte1Salle2;
    public GameObject porte2Salle2;
    public bool porte1isOpened=false;
    public bool porte2isOpened=false;
    [SerializeField]
    public Inventaire canva;

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

    public void OverturePorte1(GameObject cle, GameObject porte)
    {
        if (porte1isOpened == false)
        {
            ClassItem objectClassItem = cle.GetComponent<ClassItem>();
            if (objectClassItem.isInInventory == true)
            {
                //Debug.Log("Ya la clé");
                porte.transform.Rotate(0, 90, 0);
                porte1isOpened = true;
            }
        }
    }

    public bool CanPlayerMove()
    {
        return currentState == GameState.Playing;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

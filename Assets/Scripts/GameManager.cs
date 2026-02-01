using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

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

    public bool CanPlayerMove()
    {
        return currentState == GameState.Playing;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] 
    private bool isPaused = false; // Permet de savoir si le jeu est en pause ou non.
    public GameObject pauseMenuObject;
    public GameObject optionsMenuObject;
    [SerializeField]
    public AudioSource clickSound;

    void Start()
    {

    }


    void Update()
    {
        // Si le joueur appuis sur Echap alors la valeur de isPaused devient le contraire.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseGame();
        }

        //else
        //pauseMenuObject.SetActive(false);
        //Time.timeScale = 1.0f; // Le temps reprend


    }

    public void PauseGame()
    {
        if (isPaused)
        {

            //Time.timeScale = 0f; // Le temps s'arrete
            pauseMenuObject.SetActive(true);
            optionsMenuObject.SetActive(false);
            FirstPersonCamera.isInGame = false;
        }
       
    }

    public void ResumeGame()
    {
        pauseMenuObject.SetActive(false);
        optionsMenuObject.SetActive(false);
        //Time.timeScale = 1.0f;
        isPaused = !isPaused;
        FirstPersonCamera.isInGame = true;
    }

    public void ClickSound()
    {
        clickSound.Play();
    }

    public void MainMenu()
    {
        //Time.timeScale = 1.0f;
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitMenu()
    {
        Application.Quit();
    }
}

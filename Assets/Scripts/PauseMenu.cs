using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool isPaused = false; // Permet de savoir si le jeu est en pause ou non.
    public GameObject pauseMenuObject;

    void Start()
    {

    }


    void Update()
    {
        // Si le joueur appuis sur Echap alors la valeur de isPaused devient le contraire.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {

            //Time.timeScale = 0f; // Le temps s'arrete
            PauseGame();
        }

        //else
        //pauseMenuObject.SetActive(false);
        //Time.timeScale = 1.0f; // Le temps reprend


    }

    public void PauseGame()
    {
        pauseMenuObject.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenuObject.SetActive(false);
        //Time.timeScale = 1.0f;
        isPaused = !isPaused;
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

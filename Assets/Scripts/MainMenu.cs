using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private float intensity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //Modifier pour qu'on revienne à l'état de base ?
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void SetVolume(float sliderValue)
    {
        //AudioManager.musicVolume.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSensitivity(float sliderValue)
    {
        //FirstPersonCamera.SetFloat("mouseSensitivity", Mathf.Log10(sliderValue) * 20);
    }
}

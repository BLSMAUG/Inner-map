using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    [SerializeField]
    public Sprite sprite1;
    [SerializeField] 
    private Sprite sprite2;
    [SerializeField]
    private Image backgroundImage;

    void Start()
    {
        backgroundImage = background.GetComponent<Image>();
        StartCoroutine(MenuGlitch2());
        FirstPersonCamera.isInGame = false;
    }
    void Update() 
    {
        
     
    }

    IEnumerator MenuGlitch1()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(0.2f);
        backgroundImage.sprite = sprite1;

        StartCoroutine(MenuGlitch2());

        //backgroundImage.sprite = sprite2;
        //yield return new WaitForSeconds(10f);
    }

    IEnumerator MenuGlitch2()
    {
        Debug.Log("2");
        int time = Random.Range(1, 5);
        yield return new WaitForSeconds(time);
        backgroundImage.sprite = sprite2;
        
        StartCoroutine(MenuGlitch1());
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        FirstPersonCamera.isInGame = true;
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
}

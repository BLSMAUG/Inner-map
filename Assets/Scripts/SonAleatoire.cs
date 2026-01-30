using UnityEngine;
using System.Collections;

public class SonAleatoire : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] sons;

    public float mintemps;
    public float maxtemps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(JouerSonsAleatoire());
        
    }

    IEnumerator JouerSonsAleatoire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(mintemps, maxtemps));

            audioSource.clip = sons[Random.Range(0, sons.Length)];
            audioSource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

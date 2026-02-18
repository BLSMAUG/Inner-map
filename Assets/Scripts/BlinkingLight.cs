using System.Collections;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{

    public float minIntensity;
    public float maxIntensity;
    [SerializeField]
    public int maxTime;
   

    public Light myLight;


    void Start()
    {
        myLight = GetComponent<Light>();
        StartCoroutine(BlinkingLight1());
    }

   
    void Update()
    {
       
    }
    IEnumerator BlinkingLight1()
    {
        Debug.Log("1");
        int time = Random.Range(1, maxTime);
        yield return new WaitForSeconds(time);
        myLight.intensity = minIntensity;


        StartCoroutine(BlinkingLight2());
    }
    IEnumerator BlinkingLight2()
    {
        Debug.Log("2");
        yield return new WaitForSeconds(0.1f);
        myLight.intensity = maxIntensity;


        StartCoroutine(BlinkingLight1());
    }
}

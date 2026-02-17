using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractionObject : MonoBehaviour
{
    [SerializeField]
    public Inventaire canva;
    [SerializeField]
    public bool isOpened = false;
    //Ajouter tag isOpened pour porte ou pas mettre dans Update ???
    //POUR TESTS
    [SerializeField]
    public GameObject porte;
    [SerializeField]
    public GameObject cle;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OverturePorte(cle,porte);
    }
    public void OverturePorte(GameObject cle, GameObject porte)
    {
        if (isOpened == false)
        {
            for (int i = 0; i < canva.inventaire.Count; i++)
            {
                //Debug.Log(i);
                ClassItem objectClassItem = cle.GetComponent<ClassItem>();
                if (objectClassItem.isInInventory == true)
                {
                    //Debug.Log("Ya la cl�");
                    porte.transform.Rotate(0, 90, 0);
                    isOpened = true;
                    //DoorAndKey.Play();

                }
            }
        }
    }
}

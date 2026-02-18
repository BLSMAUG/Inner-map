using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    //Liste des slots de l'inventaire
    private int slotCount;

    [SerializeField]
    public List<GameObject> slots = new List<GameObject>();
    [SerializeField]
    public List<ClassItem> inventaire = new List<ClassItem>();
    [SerializeField]
    public List<GameObject> objects = new List<GameObject>();

    private ClassItem classItem;
    public static int nextFreeSlot = 0;

    [SerializeField]
    private GameObject ItemPrefab;

    [SerializeField]
    private GameObject Crosshair;

    [SerializeField]
    public Transform Canva;

    //POUR TESTER: a mettre en commentaire plus tard
    [SerializeField]
    private GameObject itemVise;

    [SerializeField]
    public GameObject eKey;

    [SerializeField]
    public GameObject fKey;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slotCount = slots.Count;
        //TEST DE LA FONCTION
        //AddToInventory("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        eKeyStatus();
        fKeyStatus();
        CrosshairStatus();
        //AddToInventory(PlayerRaycast.hitName);
    }

    public void eKeyStatus()
    {
        if (PlayerRaycast.eKeyState == true)
        {
            eKey.SetActive(true);
        }
        if (Dialogues.isInDialogue == true)
        {
            eKey.SetActive(false);
        }
        else if (PlayerRaycast.eKeyState == false)
        {
            eKey.SetActive(false);
        }
    }

    public void fKeyStatus()
    {
        if (PlayerRaycast.fKeyState == true)
        {
            fKey.SetActive(true);
        }
        if (Dialogues.isInDialogue == true)
        {
            fKey.SetActive(false);
        }
        else if (PlayerRaycast.fKeyState == false)
        {
            fKey.SetActive(false);
        }
    }

    public void CrosshairStatus()
    {
        if (FirstPersonCamera.isInGame == true)
        {
            Crosshair.SetActive(true);
        }
        else
        {
            Crosshair.SetActive(false);
        }
    }

    public void DeleteFromInventory(ClassItem objet)
    {
        Debug.Log("Deleting...");
        inventaire.Remove(objet);
        objet.isInInventory = false;
        Destroy(Canva.GetChild(9).gameObject);
        nextFreeSlot = nextFreeSlot - 1;
    }
        
    public void AddToInventory(string name)
    {
        Debug.Log("Started function");
        foreach (GameObject element in objects)
        {
            ClassItem objectClassItem = element.GetComponent<ClassItem>();
            //Debug.Log(element);
            Debug.Log(objects.Count);
            if (objectClassItem.itemName == name)
            {
                 Debug.Log("Ivent "+ inventaire.Count);
                // Debug.Log("slot " + slotCount);


                if (inventaire.Count < slotCount)
                {
                    //Destroy(GameObject.Find(itemName));
                     Debug.Log(objectClassItem.itemName+"YES");
                    inventaire.Add(objectClassItem);
                    //Cr�er objet sprite � partir du sprite stock� dan sl'objet
                    GameObject icone = Instantiate(ItemPrefab, Canva);
                    icone.GetComponent<Image>().sprite = objectClassItem.itemIcon;
                    icone.GetComponent<RectTransform>().anchoredPosition = slots[nextFreeSlot].GetComponent<RectTransform>().anchoredPosition;
                    objectClassItem.isInInventory = true;
                    nextFreeSlot = nextFreeSlot + 1;
                }
                else
                {
                    Debug.Log("No free inventory slots left");
                }

            }
        }

        //ClassItem objectClassItem = item.GetComponent<ClassItem>();
        //if (inventaire.Count < slotCount)
        //{ 
        //    inventaire.Add(objectClassItem);
        //    //Cr�er objet sprite � partir du sprite stock� dan sl'objet
        //    GameObject icone = Instantiate(ItemPrefab, Canva);
        //    icone.GetComponent<Image>().sprite = objectClassItem.itemIcon;
        //    icone.GetComponent<RectTransform>().anchoredPosition = slots[nextFreeSlot].GetComponent<RectTransform>().anchoredPosition;
        //    nextFreeSlot = nextFreeSlot + 1;
        //}
        //else
        //{
        //    Debug.Log(slotCount);
        //}
    }
}

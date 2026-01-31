using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.VolumeComponent;

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
    private int nextFreeSlot = 0;

    [SerializeField]
    private GameObject ItemPrefab;

    [SerializeField]
    private GameObject Crosshair;

    [SerializeField]
    private Transform Canva;

    //POUR TESTER: a mettre en commentaire plus tard
    [SerializeField]
    private GameObject itemVisé;

    [SerializeField]
    public GameObject eKey;


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
    public void AddToInventory(string name)
    {
        Debug.Log("Started function");
        for (int i = 0; i < objects.Count; i++)
        {
            ClassItem objectClassItem = objects[i].GetComponent<ClassItem>();
            Debug.Log(i);
            Debug.Log(objects.Count);
            if (objectClassItem.itemName == name)
            {
                Debug.Log("Ivent "+ inventaire.Count);
                Debug.Log("slot " + slotCount);


                if (inventaire.Count < slotCount)
                {
                    //Destroy(GameObject.Find(itemName));
                    Debug.Log(objectClassItem.itemName+"YES");
                    inventaire.Add(objectClassItem);
                    //Créer objet sprite à partir du sprite stocké dan sl'objet
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
        //    //Créer objet sprite à partir du sprite stocké dan sl'objet
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

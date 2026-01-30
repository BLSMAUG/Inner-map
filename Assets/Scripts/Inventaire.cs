using System.Collections.Generic;
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
    private List<GameObject> slots = new List<GameObject>();
    [SerializeField]
    private List<ClassItem> inventaire = new List<ClassItem>();
    [SerializeField]
    private List<GameObject> objects = new List<GameObject>();

    private ClassItem classItem;
    private int nextFreeSlot = 0;

    [SerializeField]
    private GameObject ItemPrefab;

    [SerializeField]
    private Transform Canva;

    //POUR TESTER: a mettre en commentaire plus tard
    [SerializeField]
    private GameObject itemVisé;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slotCount = slots.Count;
        //TEST DE LA FONCTION
        //AddToInventory(itemVisé);
    }

    // Update is called once per frame
    void Update()
    {
        //AddToInventory(GameObject PlayerRaycast.hitObject);
    }

    public void AddToInventory(string itemName)
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name == itemName)
            {
                ClassItem objectClassItem = objects[i].GetComponent<ClassItem>();
                if (inventaire.Count < slotCount)
                {
                    Destroy(GameObject.Find(itemName));
                    inventaire.Add(objectClassItem);
                    //Créer objet sprite à partir du sprite stocké dan sl'objet
                    GameObject icone = Instantiate(ItemPrefab, Canva);
                    icone.GetComponent<Image>().sprite = objectClassItem.itemIcon;
                    icone.GetComponent<RectTransform>().anchoredPosition = slots[nextFreeSlot].GetComponent<RectTransform>().anchoredPosition;
                    nextFreeSlot = nextFreeSlot + 1;
                }
                else
                {
                    Debug.Log("No free inventory slots left");
                }
            }
            break;
        }
        
    }
}

using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventaire : MonoBehaviour
{
    //Liste des slots de l'inventaire
    [SerializeField]
    private GameObject slot1;
    [SerializeField] 
    private GameObject slot2;
    [SerializeField] 
    private GameObject slot3;
    [SerializeField] 
    private GameObject slot4;

    private int slotCount = 4;

    private List<GameObject> slots = new List<GameObject>();
    private List<ClassItem> inventaire = new List<ClassItem>();

    private ClassItem classItem;
    private int nextFreeSlot = 0;

    //POUR TESTER: a mettre en commentaire plus tard
    [SerializeField]
    private GameObject itemVisé;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slots.Add(slot1);
        slots.Add(slot2);
        slots.Add(slot3);
        slots.Add(slot4);

        //TEST DE LA FONCTION
        AddToInventory(itemVisé);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(GameObject item)
    {
       ClassItem classItem = item.GetComponent<ClassItem>();
       Sprite icone = classItem.itemIcon;
       if (inventaire.Count < slotCount)
        {
            inventaire.Add(classItem);
            item.GetComponent<RectTransform>().anchoredPosition = slots[nextFreeSlot].GetComponent<Transform>().position;
            nextFreeSlot = nextFreeSlot + 1;
        }
    }
}

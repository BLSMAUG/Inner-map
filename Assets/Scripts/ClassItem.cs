using UnityEngine;

public class ClassItem : MonoBehaviour
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    public string itemDescription;
    [SerializeField]
    public Sprite itemIcon;
    [SerializeField]
    public bool isReachable=true;
    [SerializeField]
    public bool isCollectible = true;
    [SerializeField]
    public bool isInInventory = false;
    //[SerializeField]
    //public int itemIndex;

    static public int hitIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void SwapIndex()
    //{
    //    if (Dialogues.isInDialogue == true)
    //    {
    //        hitIndex = itemIndex;
    //        //Debug.Log(hitIndex);
    //    }
    //}

    //private void TakeItem()
    //{
    //    // A FAIRE MDR BONNE CHANCE A LA PERSONNE INCROYABLE QUI LE FERA 
    //    //UPDATE: JE CROIS QUE CEST BON MAIS  VOIR AVEC LA 3D COMMENT ON SELECTIONNE CETTE MERDE
    //}
}

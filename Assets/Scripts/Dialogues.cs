using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    static public bool isInDialogue = false;
    static public string ligneDialogue;
    static public int nextLine = 0;
    static public int currentDialogue = 0;
    static public int indexDialogue;
    [SerializeField]
    public GameObject dialogueBox;
    [SerializeField]
    public GameObject enterKey;
    [SerializeField]
    public GameObject textField;

    [SerializeField]
    public AudioSource click_dialogue;



    public List<string[]> DialogueList = new List<string[]>() { StartingDialogue, ForainDialogue, StartingLetterDialogue, DoorLockedWithKeyDialogue, DoorLockedDialogue, DoorWhenUnlockedWithKeyDialogue, PickUpKeyDialogue, FishermanDialogue, NoteTheWorkerDialogue, GeneratorWithoutFuseDialogue, PickUpFuseDialogue, PickUpCatchingNet, FirstKeyDialogue, SecondKeyDialogue, MaskDialogue, PickUpMaskDialogue, CatchingNetDialogue, FuseDialogue};
    static public string[] StartingDialogue = new string[] { "... ... ...", "Why am i here ?", "My memories are messing with me, i can't remember." }; //index 0
    static public string[] ForainDialogue = new string[] { "Hey you ! I'm up here !", "You have to help me !", "You need to fix the generator, behind the ferris wheel !" }; //1
    static public string[] StartingLetterDialogue = new string[] { "The journey is painful, the end is full of sorrow.", "Don't leave, stay with me till the end." }; //2
    static public string[] DoorLockedWithKeyDialogue = new string[] { "This door can be unlocked with a key." }; //3
    static public string[] DoorLockedDialogue = new string[] { "It's locked." }; //4
    static public string[] DoorWhenUnlockedWithKeyDialogue = new string[] {"The door is now open"}; //5
    static public string[] PickUpKeyDialogue = new string[] { "You have picked up a key, it is now in your inventory." }; //6
    static public string[] FishermanDialogue = new string[] { "Well then, are you lost ?", "At this rate, I'm gonna call you Dory.", " And by the way, the kid's net isn't just for catching toy ducks...good fishing, Dory" }; //7
    static public string[] NoteTheWorkerDialogue = new string[] { "Notice to all park employees,", "Some Kids find funny to activate the ferris wheel at night.", "To fix this, I had to hide fuse somewhere the kids couldn't reach." }; //8
    static public string[] GeneratorWithoutFuseDialogue = new string[] { "A fuse is missing." }; //9
    static public string[] PickUpFuseDialogue = new string[] { "You have picked up a fuse, it is now in your inventory." }; //10
    static public string[] PickUpCatchingNet = new string[] { "You have picked up a catching net, it is now in your inventory." }; //11
    static public string[] FirstKeyDialogue = new string[] { "There is a symbol engraved on the key" }; //12
    static public string[] SecondKeyDialogue = new string[] { "There is a <Storage> label on the key"}; //13
    static public string[] MaskDialogue = new string[] { "The employee's body disintegrated and this mask took it's place.", "The mask looks like it could fit in that big door you saw earlier." }; //14
    static public string[] PickUpMaskDialogue = new string[] { "You have picked up the mask, it is now in your inventory." }; //15
    static public string[] CatchingNetDialogue = new string[] { "This catching net could let you reach a faraway object." }; //16
    static public string[] FuseDialogue = new string[] { "This should be the fuse for the generator." }; //17



    void Start()
    {
        //indexDialogue = 1;
        //ligneDialogue = DialogueList[currentDialogue][nextLine];
        //Debug.Log(ligneDialogue);
    }

    void Update()
    {
        LancerDialogue();
        TestDialogue();
        Dialogue();
    }

    public void Dialogue()
    {
        if (isInDialogue == true)
        {
            currentDialogue = ClassItem.hitIndex;
            FirstPersonCamera.isInGame = false;
            dialogueBox.SetActive(true);
            enterKey.SetActive(true);
            ligneDialogue = DialogueList[currentDialogue][nextLine];
            //Debug.Log(ligneDialogue);

            textField.GetComponent<Text>().text = ligneDialogue;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                click_dialogue.Play();
                if (nextLine < DialogueList[currentDialogue].Length - 1)
                {
                    nextLine += 1;
                }
                else
                {
                    isInDialogue = false;
                    nextLine = 0;
                    //Debug.Log("Exited dialogue");
                    FirstPersonCamera.isInGame = true;
                }

            }
        }
        else
        {
            dialogueBox.SetActive(false);
            enterKey.SetActive(false);
        }
    }
    
    public void TestDialogue()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            textField.GetComponent<Text>().text = DialogueList[currentDialogue][nextLine];

            Debug.Log(nextLine);
            Debug.Log(DialogueList[currentDialogue][nextLine]);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            currentDialogue = indexDialogue;
        }
    }
    public void LancerDialogue()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isInDialogue = true;
        }
    }

    public void TestInterractionDialogue()
    {

    }

}

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



    public List<string[]> DialogueList = new List<string[]> () { StartingDialogue, ForainDialogue, StartingLetterDialogue, DoorLockedWithKeyDialogue, DoorLockedDialogue, DoorWhenUnlockedWithKeyDialogue, KeyDialogue, FishermanDialogue, NoteTheWorkerDialogue};
    static public string[] StartingDialogue = new string[] { "... ... ...", "Why am i here ?", "My memories are messing with me, i can't remember." };
    static public string[] ForainDialogue = new string[] { "Hey you ! I'm up here !", "You have to help me !", "You need to fix the generator, behind the ferris wheel !" };
    static public string[] StartingLetterDialogue = new string[] { "The journey is painful, the end is full of sorrow.", "Don't leave, stay with me till the end." };
    static public string[] DoorLockedWithKeyDialogue = new string[] { "This door can be unlocked with a key." };
    static public string[] DoorLockedDialogue = new string[] { "It's locked." };
    static public string[] DoorWhenUnlockedWithKeyDialogue = new string[] {"The door is now open"};
    static public string[] KeyDialogue = new string[] { "The key is now in my inventory." };
    static public string[] FishermanDialogue = new string[] { "Well then, are you lost ?", "At this rate, I'm gonna call you Dory.", " And by the way, the kid's net isn't just for catching toy ducks...good fishing, Dory" };
    static public string[] NoteTheWorkerDialogue = new string[] { "Notice to all park employees,", "Some Kids find funny to activate the ferris wheel at night.", "To fix this, I had to hide fuse somewhere the kids couldn't reach." };
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

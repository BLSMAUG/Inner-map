using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class Dialogues : MonoBehaviour
{
    public bool isInDialogue = false;
    public string ligneDialogue;
    public int nextLine = 0;
    public int currentDialogue;
    public int indexDialogue;
    [SerializeField]
    private GameObject dialogueBox;

    public List<string[]> DialogueList = new List<string[]> () { StartingDialogue, ForainDialogue, StartingLetterDialogue, DoorLockedWithKeyDialogue, DoorLockedDialogue, DoorWhenUnlockedWithKeyDialogue, KeyDialogue};
    static public string[] StartingDialogue = new string[] { "... ... ...", "Why am i here ?", "My memories are messing with me, i can't remember." };
    static public string[] ForainDialogue = new string[] { "Hey you ! I'm up here !", "You have to help me !", "You need to fix the generator, behind the ferris wheel !" };
    static public string[] StartingLetterDialogue = new string[] { "The journey is painful, the end is full of sorrow.", "Don't leave, stay with me till the end." };
    static public string[] DoorLockedWithKeyDialogue = new string[] { "This door can be unlocked with a key." };
    static public string[] DoorLockedDialogue = new string[] { "It's locked." };
    static public string[] DoorWhenUnlockedWithKeyDialogue = new string[] {"The door is now open"};
    static public string[] KeyDialogue = new string[] { "The key is now in my inventory." };

    void Start()
    {
        indexDialogue = 1;
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
            FirstPersonCamera.isInGame = false;
            dialogueBox.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                
                if (nextLine < DialogueList[currentDialogue].Length - 1)
                {
                    nextLine += 1;
                }
                else
                {
                    isInDialogue = false;
                    nextLine = 0;
                    Debug.Log("Exited dialogue");
                    FirstPersonCamera.isInGame = true;
                }

            }
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
    
    public void TestDialogue()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
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



}

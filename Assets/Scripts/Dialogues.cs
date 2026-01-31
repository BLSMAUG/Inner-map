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

    public List<string[]> DialogueList = new List<string[]> () { StartingDialogue, ForainDialogue };
    static public string[] StartingDialogue = new string[] { "Ligne 1", "Ligne 2", "Ligne 3" };
    static public string[] ForainDialogue = new string[] { "Texte 1", "Texte 2", "Texte 3" };

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

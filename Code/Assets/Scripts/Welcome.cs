using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is a copy of the DialogueAutoStart class, designed to check if a user has entered the room before, and only run the welcome message if 
//they haven't been in the scene before
public class Welcome : MonoBehaviour
{
    public Sentence[] WelcomeStrings;
    
    //Needs to be assigned in the Inspector
    public GameObject DialogueBox;
    public GameObject[] ResponseButton;

    //These will always be the same for the welcome, so we can skip them
    private string[] choices = new string[1];

    private bool wait = true;


    // Start is called before the first frame update
    void Start()
    {

        choices[0] = "I got this.";

        //If the user hasn't played through the Janitor's Closet scene of the tutorial before, Globals.StorageRoom will be false
        //StorageRoom is set to true in ChoiceHandler.BackToHall()
        if (!InteractionsCounter.intro){
            
            if (wait)
                StartCoroutine(TriggerDialogue());
            else
                TriggerDialogueNoWait();
        }
        else {

        }
    }

    //Waits for 1.5 seconds to be sure that the scene transition is done
    IEnumerator TriggerDialogue()
    {
        yield return new WaitForSeconds(1.5f);
        
        if (DialogueBox != null)
            DialogueBox.SetActive(true);

        FindObjectOfType<DialogueManager>().StartDialogue(WelcomeStrings, choices, ResponseButton);
    }

    //Starts the dialogue immediately
    public void TriggerDialogueNoWait()
    {
        if (DialogueBox != null)
            DialogueBox.SetActive(true);

        FindObjectOfType<DialogueManager>().StartDialogue(WelcomeStrings, choices, ResponseButton);
    }

    public void WelcomeOver(){
        Globals.canClick = true;
        InteractionsCounter.intro = true;
    }

}

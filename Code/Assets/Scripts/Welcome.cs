using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is a copy of the DialogueAutoStart class, designed to check if a user has entered the room before, and only run the welcome message if 
//they haven't been in the scene before
public class Welcome : MonoBehaviour
{
    private Sentence[] welcomespeech = new Sentence[3];
    
    //Needs to be assigned in the Inspector
    public GameObject HeadsUpDisplay;
    public GameObject[] choiceButtons = new GameObject[3];

    //These will always be the same for the welcome, so we can skip them
    private string[] choices = new string[1];

    private bool wait = true;

    private bool speech = false;


    // Start is called before the first frame update
    void Start()
    {
        string[] WelcomeStrings = new string[] {"Welcome to Lyssa Psychiatric Institution.", "Use the WASD or arrow keys to move around.", "You can view your inventory & objectives by clicking on your avatar or using the I key."};


        //Instantiates a Dialogue object which contains the sentences from the WelcomeStrings array
        for (int i = 0; i < 3; i++){
            welcomespeech[i] = new Sentence(WelcomeStrings[i]);
        }

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
        
        if (HeadsUpDisplay != null)
            HeadsUpDisplay.SetActive(true);

        FindObjectOfType<DialogueManager>().StartDialogue(welcomespeech, choices, choiceButtons, speech);
    }

    //Starts the dialogue immediately
    public void TriggerDialogueNoWait()
    {
        if (HeadsUpDisplay != null)
            HeadsUpDisplay.SetActive(true);

        FindObjectOfType<DialogueManager>().StartDialogue(welcomespeech, choices, choiceButtons, speech);
    }

    public void WelcomeOver(){
        Globals.canClick = true;
        InteractionsCounter.intro = true;
        FindObjectOfType<DialogueManager>().setConversationStatus(false);
    }

}

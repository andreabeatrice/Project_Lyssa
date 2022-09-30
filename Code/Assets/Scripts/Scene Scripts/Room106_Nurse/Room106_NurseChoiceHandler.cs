using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room106_NurseChoiceHandler : MonoBehaviour
{

    public GameObject[] keycardResponseChoices_lie;
    public GameObject[] keycardResponseChoices;
    public AudioSources allAudio;
    public GameObject leaveroombutton;

    public GameObject grafitti; 
    public Sprite insaneGrafitti;

    public void Start(){
        if (Globals.insanity > 4){
            grafitti.GetComponent<Image>().sprite = insaneGrafitti;
        }
    }

    public void blamed_receptionist(){
        Globals.insanity += 2;

        allAudio.StopAllAudio();

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        //string[] s = {"Yes! She specifically told me that this room needed to be cleaned out!"};
        Sentence[] s = new Sentence[3];
        
        s[0] = new Sentence("Yes! She specifically told me that this room needed to be cleaned out!", 1);
        s[1] = new Sentence("I knew it! I'll have to speak to Dr Kraus about her.");
        s[2] = new Sentence("Say, since you're in here anyway, have you seen my key card?");

        FindObjectOfType<DialogueManager>().StartDialogue(s, determineChoicesStrings(), determineChoicesButtons(), true);

        //StartCoroutine(nurse_response_receptionist());
    }

    public void be_honest(){
        Globals.insanity -= 1;

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        Sentence[] s;

        if(Globals.insanity >= 5){
            s = new Sentence[4];
            s[0] = new Sentence("There are rats around, I was trying to catch one.", 1);
            s[1] = new Sentence("God, you're really the worst janitor, Fern");
            s[1] = new Sentence("... though I'm not really surprised. She's a bit of an idiot.");
            s[2] = new Sentence("Say, since you're in here anyway, have you seen my key card?");
        } 
        else {
            s = new Sentence[3];
            s[0] = new Sentence("There are rats around, I was trying to catch one.", 1);
            s[1] = new Sentence("God, you're really the worst janitor, Fern.");
            s[2] = new Sentence("Say, since you're in here anyway, have you seen my key card?");
        }

        FindObjectOfType<DialogueManager>().StartDialogue(s, determineChoicesStrings(), determineChoicesButtons(), true);
    
    }

    public void keycardlie(){
        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        Globals.insanity += 1;

        Sentence[] s = new Sentence[]{new Sentence("Ugh, it will be a mission to get to the basement without it."), new Sentence("Are you still here? Get back to work!")};

        FindObjectOfType<DialogueManager>().StartDialogue(s, "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Investigate the basement");
    }

    public void keycardtruth_here(){
        HelperMethods.InventoryDequeue("Nurse's Keycard");

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        Sentence[] s = new Sentence[]{new Sentence("Oh, brilliant! We can't have anyone getting into the basement. Now get back to work!"), new Sentence("Oh, and take this trash she was keeping under her pillow with you!")};

        HelperMethods.InventoryEnqueue("Note from Otto");
        
        FindObjectOfType<DialogueManager>().StartDialogue(s, "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Find the note writer");
    }

    public void keycardtruth(){
        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

       Sentence[] s = new Sentence[]{new Sentence("Ugh, it's probably around here somewhere."), new Sentence("Are you still here? Get back to work!")};

        FindObjectOfType<DialogueManager>().StartDialogue(s, "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Find the note writer");
    }

    public GameObject[] determineChoicesButtons(){
        
        foreach(string i in Globals.inventory){
            if(i.Contains("Keycard")){
                return keycardResponseChoices_lie;
            }
            if(i.Contains("Note")){

                return keycardResponseChoices;

            }
        }
        return null;

    }

    public string[] determineChoicesStrings(){
        
        string[] choicePhrases =  new string[2];

        foreach(string i in Globals.inventory){
            if(i.Contains("Keycard")){
                choicePhrases[0] = "Yes, it's right here (+0)";
                choicePhrases[1] = "Nope, haven't seen it (+1)";
            }
            if(i.Contains("Note")){
                choicePhrases[0] = "No clue (+0)";
                choicePhrases[1] = "Nope, haven't seen it (+0)";

            }
        }
        return choicePhrases;

    }

    public void leaveroom(){
        Debug.Log(HelperMethods.CheckInventory("Note"));
        if (HelperMethods.CheckInventory("Note")){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_4_Note", "crossfade_start");
        }
        else {
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_5_Keycard", "crossfade_start");
        }

        
    }
}

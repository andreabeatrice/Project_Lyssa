using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room106_NurseChoiceHandler : MonoBehaviour
{

    public GameObject[] keycardResponseChoices_lie;
    public GameObject[] keycardResponseChoices;
    public AudioSources allAudio;
    public GameObject leaveroombutton;

    public void blamed_receptionist(){
        Globals.insanity += 2;

        allAudio.StopAllAudio();

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Yes! She specifically told me that this room needed to be cleaned out!"};


        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Fern", Globals.fernspeech, allAudio.fern_voice), "", null, true);

        StartCoroutine(nurse_response_receptionist());
    }

    public void be_honest(){
        Globals.insanity -= 1;

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"There are rats around, I was trying to catch one."};

        //FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Fern", Globals.fernspeech, FindObjectOfType<AudioSources>().fern_voice), "", null, false);
        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Fern", Globals.fernspeech, allAudio.fern_voice), "", null, true);
        StartCoroutine(nurse_response_rats());
    }

    public IEnumerator nurse_response_receptionist() //each sentence
    {

        yield return new WaitForSeconds(2.5f);

       Debug.Log("check1");


        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"I knew it! I'll have to speak to Dr Kraus about her.", "Say, since you're in here anyway, have you seen my key card?"};

        determineChoices(s);
    }

    public IEnumerator nurse_response_rats() //each sentence
    {

        yield return new WaitForSeconds(2.5f);

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s;

        if(Globals.insanity >= 5){
            s = new string[3];
            s[0] = "God, you're really the worst janitor, Fern.";
            s[1] = "<i> and you have always been a bit of an idiot.</i>";
            s[2] = "Say, since you're in here anyway, have you seen my key card?";
        } 
        else {
            s = new string[2];
            s[0] = "God, you're really the worst janitor, Fern.";
            s[1] = "Say, since you're in here anyway, have you seen my key card?";
        }


        determineChoices(s);
        
    }

    public void keycardlie(){
        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();
        Globals.insanity += 1;

        string[] s = {"Ugh, it will be a mission to get to the basement without it.", "Are you still here? Get back to work!"};

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr", FindObjectOfType<AudioSources>().nurse_voice), "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Investigate the basement");
    }

    public void keycardtruth_here(){
        HelperMethods.InventoryDequeue("Nurse's Keycard");

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Oh, brilliant! We can't have anyone getting into the basement. Now get back to work!", "Oh, and take this piece of paper with you!"};

        HelperMethods.InventoryEnqueue("Note from Otto");
        
        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr", FindObjectOfType<AudioSources>().nurse_voice), "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Find the note writer");
    }

    public void keycardtruth(){
        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Ugh, it's probably around here somewhere. Go get back to work!"};

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr", FindObjectOfType<AudioSources>().nurse_voice), "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Find the note writer");
    }

    public void determineChoices(string[] s){
        
        Debug.Log(FindObjectOfType<AudioSources>().nurse_voice);
        string[] choicePhrases =  new string[2];

        foreach(string i in Globals.inventory){
            if(i.Contains("Keycard")){
                choicePhrases[0] = "Yes, I have it here (+0)";
                choicePhrases[1] = "Nope, haven't seen it (+1)";

                FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr", FindObjectOfType<AudioSources>().nurse_voice), choicePhrases, keycardResponseChoices_lie, true);

                break;

            }
            if(i.Contains("Note")){
                choicePhrases[0] = "No clue (+0)";
                choicePhrases[1] = "Nope, haven't seen it (+0)";

                FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr", FindObjectOfType<AudioSources>().nurse_voice), choicePhrases, keycardResponseChoices, true);

                break;
            }
        }

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

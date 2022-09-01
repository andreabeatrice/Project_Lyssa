using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room106_ChoiceHandler : MonoBehaviour
{
    public GameObject[] keycardResponseChoices_lie;
    public GameObject[] keycardResponseChoices;

    public GameObject leaveroombutton;
    // Start is called before the first frame update
    void Start()
    {
        //Globals.insanity = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keep_antipsychotics(){

        HelperMethods.InventoryEnqueue("Antipyschotic Pill");

        GameObject.Find("Pill").SetActive(false);

        FindObjectOfType<DialogueBoxHandler>().clearHUD();
    }

    public void leave_object(){
        FindObjectOfType<DialogueBoxHandler>().clearHUD();
    }

    public void keep_keycard(){
        HelperMethods.InventoryEnqueue("Nurse's Keycard");

        HelperMethods.ObjectivesDequeue("Find the note from Otto");
        HelperMethods.ObjectivesDequeue("Find the nurse's key card");

        GameObject.Find("keycard collider").SetActive(false);

        //play footsteps noise + dialogue
        FindObjectOfType<AudioSources>().StopAllAudio();
        FindObjectOfType<AudioSources>().playFootsteps();
        //FindObjectOfType<DialogueManager>().TypeSentence("Someone's coming!");

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Someone's coming!"};

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, null, Globals.fernspeech), "", null, false);

        StartCoroutine(NurseScene());


    }

    public void keep_note(){
        HelperMethods.InventoryEnqueue("Note from Otto");

        HelperMethods.ObjectivesDequeue("Find the note from Otto");
        HelperMethods.ObjectivesDequeue("Find the nurse's key card");

        GameObject.Find("Note").SetActive(false);

        //play footsteps noise + dialogue
        FindObjectOfType<AudioSources>().StopAllAudio();
        FindObjectOfType<AudioSources>().playFootsteps();
        //FindObjectOfType<DialogueManager>().TypeSentence("Someone's coming!");

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Someone's coming!"};

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, null, Globals.fernspeech), "", null, false);

        StartCoroutine(NurseScene());


    }

    public void investigate_writing(){
        Globals.insanity +=1;
        DestroyImmediate(GameObject.Find("writing on the walls").GetComponent<Collider2D>());
        FindObjectOfType<DialogueBoxHandler>().clearHUD();
    }

    public IEnumerator NurseScene() //each sentence
    {

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Room106_Nurse");
        
    }

    public void blamed_receptionist(){
        Globals.insanity += 2;

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Yes! She specifically told me that this room needed to be cleaned out!"};

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Fern", Globals.fernspeech), "", null, false);

        StartCoroutine(nurse_response_receptionist());
    }

    public void be_honest(){
        Globals.insanity -= 1;

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"There are rats around, I was trying to catch one."};

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Fern", Globals.fernspeech), "", null, false);

        StartCoroutine(nurse_response_rats());
    }

    public IEnumerator nurse_response_receptionist() //each sentence
    {

        yield return new WaitForSeconds(2.5f);

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

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr"), "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Investigate the basement");
    }

    public void keycardtruth_here(){
        HelperMethods.InventoryDequeue("Nurse's Keycard");

        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Oh, brilliant! We can't have anyone getting into the basement. Now get back to work!", "Oh, and take this piece of paper with you!"};

        HelperMethods.InventoryEnqueue("Note from Otto");
        
        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr"), "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Find the note writer");
    }

    public void keycardtruth(){
        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        string[] s = {"Ugh, it's probably around here somewhere. Go get back to work!"};

        FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr"), "Yes, nurse", leaveroombutton, true);

        HelperMethods.ObjectivesEnqueue("Find the note writer");
    }

    public void determineChoices(string[] s){
        string[] choicePhrases =  new string[2];

        foreach(string i in Globals.inventory){
            if(i.Contains("Keycard")){
                choicePhrases[0] = "Yes, I have it here (+0)";
                choicePhrases[1] = "Nope, haven't seen it (+1)";

                FindObjectOfType<DialogueManager>().StartDialogue(new Dialogue(s, "Nurse Tarr"), choicePhrases, keycardResponseChoices_lie, true);

                break;

            }
            if(i.Contains("Note")){
                choicePhrases[0] = "It's porbably around here (+0)";
                choicePhrases[1] = "Nope, haven't seen it (+0)";
                break;
            }
        }

    }

    public void leaveroom(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_post106", "crossfade_start");
    }

}

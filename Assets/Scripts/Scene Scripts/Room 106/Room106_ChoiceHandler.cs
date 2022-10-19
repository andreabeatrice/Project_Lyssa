using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room106_ChoiceHandler : MonoBehaviour
{
    public AudioSources AllAudio;
    public GameObject WallWritings, AntipsychoticPill, Keycard, Note, ManagerHolder;
    // Start is called before the first frame update
    void Start()
    {
        //Globals.insanity = 4;
        // foreach(string s in Globals.objectives){
        //     Globals.objectives.Dequeue();
        // }

        HelperMethods.PrintObjectives();

        HelperMethods.ObjectivesDequeue("Go clean the patients' rooms.");

        HelperMethods.ObjectivesEnqueue("Don't get fired");

        if (Globals.insanity < 3){
            HelperMethods.ObjectivesEnqueue("Find the rat?");
        }

        HelperMethods.ObjectivesEnqueue("Find HER");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeepAntipsychotic(){

        HelperMethods.InventoryEnqueue("Antipsychotic Pill");

        AntipsychoticPill.SetActive(false);

        ManagerHolder.GetComponent<DialogueBoxHandler>().ClearDialogueBox();
    }

    public void KeepKeycard(){
        HelperMethods.InventoryEnqueue("Nurse's Keycard");

        HelperMethods.ObjectivesDequeue("Find the note from Otto");
        HelperMethods.ObjectivesDequeue("Find the nurse's key card");

        Keycard.SetActive(false);

        //play footsteps noise + dialogue
        FindObjectOfType<AudioSources>().StopAllAudio();
        FindObjectOfType<AudioSources>().playFootsteps();
        //FindObjectOfType<DialogueManager>().TypeSentence("Someone's coming!");

        ManagerHolder.GetComponent<DialogueBoxHandler>().ClearChoiceButtons();

        Sentence[] se = new Sentence[]{new Sentence("Someone's coming!", null, "Fern", ColorCodes.fern)};

        ManagerHolder.GetComponent<DialogueManager>().StartDialogue(se, "", null);

        StartCoroutine(NurseScene());


    }

    public void KeepOttosNote(){
        HelperMethods.InventoryEnqueue("Note from Otto");

        HelperMethods.ObjectivesDequeue("Find the note from Otto");
        HelperMethods.ObjectivesDequeue("Find the nurse's key card");

        Note.SetActive(false);

        //play footsteps noise + dialogue
        FindObjectOfType<AudioSources>().StopAllAudio();
        FindObjectOfType<AudioSources>().playFootsteps();

        ManagerHolder.GetComponent<DialogueBoxHandler>().ClearChoiceButtons();

        Sentence[] se = new Sentence[]{new Sentence("Someone's coming!", null, "Fern", ColorCodes.fern)};

        ManagerHolder.GetComponent<DialogueManager>().StartDialogue(se);

        FindObjectOfType<LevelLoader>().LoadNextLevelLong("Room106_Nurse", "crossfade_start", 4f);


    }

    public void ExamineWall(){
        Globals.insanity +=1;
        DestroyImmediate(WallWritings.GetComponent<Collider2D>());
        ManagerHolder.GetComponent<DialogueBoxHandler>().ClearDialogueBox();
    }

    public IEnumerator NurseScene() //each sentence
    {

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Room106_Nurse");
        
    }

   

}

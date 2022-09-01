using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room106_ChoiceHandler : MonoBehaviour
{
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



        
}

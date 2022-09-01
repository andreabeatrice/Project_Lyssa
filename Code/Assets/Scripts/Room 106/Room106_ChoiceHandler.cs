using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room106_ChoiceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

        //change draw sprite 2 without keycard

        //play footsteps noise + dialogue

        //wait two seconds

        //change scene?


    }

    public void investigate_writing(){
        Globals.insanity +=1;
    }



        
}

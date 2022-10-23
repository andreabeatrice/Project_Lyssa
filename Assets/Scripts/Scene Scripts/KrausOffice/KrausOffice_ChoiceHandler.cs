using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrausOffice_ChoiceHandler : MonoBehaviour
{
    public GameObject CanvasPinboard, DialougeBox;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaveOffice(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_7_LightSwitch", "crossfade_start");
    }

    public void LeaveOfficeSnuckIn(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_5_Keycard", "crossfade_start");
    }

    public void LeaveOfficeNotePath(){
        if (HelperMethods.CheckObjectives("Find the secret entrance to the basement.")){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_10_Piano", "crossfade_start");
        }
        else {
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_9_Kitchen", "crossfade_start");
        }
        
    }


    public void SheTakesAWhiskeyDrink(){
        Globals.insanity += 1;
        DialougeBox.GetComponent<DialogueBoxHandler>().ClearDialogueBox();
    }

    public void ShowCanvasPinboard(){
        CanvasPinboard.SetActive(true);
    }

    public void HideCanvasPinboard(){
        CanvasPinboard.SetActive(false);
    }

    public void Pause(){
        Globals.paused = true;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrausOffice_ChoiceHandler : MonoBehaviour
{
    public GameObject CanvasPinboard;
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


    public void SheTakesAWhiskeyDrink(){
        Globals.insanity += 1;
        FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_5_KeycardChoiceHandler : MonoBehaviour
{

    public Collider2D PlayerCollider;

    public Collider2D OfficeDoor;

    public bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWhatPlayersTouching();
    }

    public void CheckWhatPlayersTouching()
    {
        if (PlayerCollider.IsTouching(OfficeDoor) && played == false && !Globals.LightSwitch ){
            OfficeDoor.GetComponent<DialogueClick>().TriggerDialogue();

            played = true;
        }
    }

    public void EnterOffice(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("KrausOffice_1_FromHall", "crossfade_start");
    }

 
}

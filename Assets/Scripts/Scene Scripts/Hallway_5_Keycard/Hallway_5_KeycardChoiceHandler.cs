using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_5_KeycardChoiceHandler : MonoBehaviour
{

    public Collider2D PlayerCollider;

    public Collider2D OfficeDoor, commonroom, kitchen, cm2;

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
        if (commonroom!= OfficeDoor && PlayerCollider.IsTouching(OfficeDoor) && played == false && !Globals.LightSwitch ){
            OfficeDoor.GetComponent<DialogueClick>().TriggerDialogue();

            played = true;
        }
        else if (commonroom!= null && PlayerCollider.IsTouching(commonroom) && played == false && Input.GetKeyDown(KeyCode.LeftArrow)){
            commonroom_innocent();

            played = true;
        }
        else if (kitchen != null && PlayerCollider.IsTouching(kitchen) && played == false && Input.GetKeyDown(KeyCode.RightArrow)){
            toKitchen();

            played = true;
        }
    }

    public void EnterOffice(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("KrausOffice_1_FromHall", "crossfade_start");
    }

    public void commonroom_innocent(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("CommonRoom_2_KeycardPath", "crossfade_start");
    }

    public void commonroom_empty(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("CommonRoom_3_Empty", "crossfade_start");
    }

    public void toKitchen(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Kitchen", "crossfade_start");
    }

 
}

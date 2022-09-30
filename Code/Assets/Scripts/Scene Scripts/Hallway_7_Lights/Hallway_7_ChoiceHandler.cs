using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_7_ChoiceHandler : MonoBehaviour
{
    public Collider2D PlayerCollider;

    public Collider2D OfficeDoor, invisibleWall, basement;

    public bool played = false;
    public bool playedDenial = false;
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
        if (PlayerCollider.IsTouching(OfficeDoor)){
            FindObjectOfType<LevelLoader>().LoadNextLevel("KrausOffice_2_LightSwitch", "crossfade_start");
        }
        if (PlayerCollider.IsTouching(invisibleWall) && played == false){
            invisibleWall.GetComponent<DialogueClick>().TriggerDialogue();
            played = true;

        }
        if (PlayerCollider.IsTouching(basement) && !playedDenial && !Globals.LightSwitch){
            basement.GetComponent<DialogueClick>().TriggerDialogue();
            playedDenial = true;

        }
        if (PlayerCollider.IsTouching(basement) && !playedDenial && Globals.LightSwitch){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_1_LitUp", "crossfade_start");
        }
    }

    public void EnterOffice(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("KrausOffice_1_FromHall", "crossfade_start");
    }
}

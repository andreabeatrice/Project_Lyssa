using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hallway_5_KeycardChoiceHandler : MonoBehaviour
{

    public Collider2D PlayerCollider;

    public Collider2D OfficeDoor, commonroom, kitchen, cm2;

    public bool played = false;

    public GameObject DialogueBoxHolder;
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
        if (OfficeDoor!= null && PlayerCollider.IsTouching(OfficeDoor) && played == false && !Globals.LightSwitch && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))){
            if (SceneManager.GetActiveScene().name == "Hallway_9_Kitchen" || SceneManager.GetActiveScene().name == "Hallway_10_Piano"){
                FindObjectOfType<LevelLoader>().LoadNextLevel("KrausOffice_3_NotePath", "crossfade_start");
            }
            else {
                if (InteractionsCounter.krausoffice == 0){
                    OfficeDoor.GetComponent<DialogueClick>().TriggerDialogue();
                }
                else {
                    Sentence[] convincingDialogue = new Sentence[]{ 
                            new Sentence("Don't you think that's enough for one day?", null, "", new Color32(255,255,255,255)),
                    };

                    DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue);

                }
                

                played = true;
            }

        }
        
        if (commonroom!= null && PlayerCollider.IsTouching(commonroom) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))){
            commonroom_innocent();

            played = true;
        }
        if (cm2!= null && PlayerCollider.IsTouching(cm2) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))){
            commonroom_empty();

            played = true;
        }
        if (kitchen != null && PlayerCollider.IsTouching(kitchen) && played == false && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))){
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

        if (SceneManager.GetActiveScene().name ==  "Hallway_5_Keycard"){
            FindObjectOfType<LevelLoader>().LoadNextLevel("DiningHall_3_KeycardPath", "crossfade_start");
        }
        else {
            FindObjectOfType<LevelLoader>().LoadNextLevel("DiningHall_Base", "crossfade_start");
        }
        
    }

 
}

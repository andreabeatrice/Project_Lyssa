using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplorationHandler : MonoBehaviour
{
     AudioSources allAudio;

     string into_room_x;

     GameObject silent_agreement;

      public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;

    // Start is called before the first frame update
    void Start()
    {
        allAudio = FindObjectOfType<AudioSources>();
        silent_agreement = GameObject.Find("basement_agreement");
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space) && PlayerCollider != null && PlayerCollider.IsTouching(ObjectAreaCollider) &&  SceneManager.GetActiveScene().name.Contains("Hallway"))
            OnMouseDown();
    }

    void OnMouseDown()
    {
        if (Globals.StorageRoom == true){
            allAudio.playOpenDoor();
            FindObjectOfType<LevelLoader>().LoadNextLevel(this.name, "crossfade_start");
        }
        else {
            FindObjectOfType<DialogueBoxHandler>().ShowDialogueBox();

            Sentence[] interaction = new Sentence[] {new Sentence("I should go get cleaning supplies first", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction, "Yeah, okay", silent_agreement);

            allAudio.playErrorSound();
        }
    }

    public void BackToHall(){
        allAudio.playOpenDoor();
        if(HelperMethods.CheckInventory("Note from Otto") && !SceneManager.GetActiveScene().name.Contains("CommonRoom")){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_4_Note", "crossfade_start");
        }
        else if (HelperMethods.CheckInventory("Keycard")){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_5_Keycard", "crossfade_start");
        }
        else if (SceneManager.GetActiveScene().name.Contains("CommonRoom_3_Empty")){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_9_Kitchen", "crossfade_start");
        }
        else {
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_2_Pre106", "crossfade_start");
        }
        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
         if(Input.GetKeyDown(KeyCode.Space) && PlayerCollider.IsTouching(ObjectAreaCollider))
            OnMouseDown();
    }

    void OnMouseDown()
    {
        if (Globals.StorageRoom == true){
            allAudio.playOpenDoor();
            FindObjectOfType<LevelLoader>().LoadNextLevel(this.name, "crossfade_start");
        }
        else {
            FindObjectOfType<DialogueBoxHandler>().showHUD();
            string[] bucketSentences = new string[] {"I should go get cleaning supplies first"};

            //Calls the Dialogue class constructor in order to display the bucketSentences
            Dialogue bucketDialogue = new Dialogue(bucketSentences, "Fern", null);

            FindObjectOfType<DialogueManager>().StartDialogue(bucketDialogue, "Yeah, okay", silent_agreement, false);

            allAudio.playErrorSound();
        }
    }

    public void BackToHall(){
        allAudio.playOpenDoor();
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_2_Pre106", "crossfade_start");
    }
}

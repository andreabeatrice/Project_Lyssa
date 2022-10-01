using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorsDoorRedirect : MonoBehaviour
{
    AudioSources allAudio;
    GameObject NoActionChoiceButton;
    public GameObject HeadsUpDisplay;
    //Proximity Abilities enabled
    public bool enableProximityReactions;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;

    void Start(){
        allAudio = FindObjectOfType<AudioSources>();
        NoActionChoiceButton = GameObject.Find("basement_agreement");
    }

    void Update(){
        if (enableProximityReactions== true && PlayerCollider.IsTouching(ObjectAreaCollider)){

            if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused ){
                handle();
            }
            

        }
    }


    //OnMouseDown(): if the Collider attached to the object the script is attached to is clicked
    private void OnMouseOver(){
            
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused ){
                handle();
            }
    }

    public void handle(){
        allAudio.playErrorSound();

        HeadsUpDisplay.SetActive(true);


        Sentence[] dialog = new Sentence[] {new Sentence("I don't need to do that again right now.", 1)};

        FindObjectOfType<DialogueManager>().StartDialogue(dialog, "Okay", NoActionChoiceButton, false);
    }
}

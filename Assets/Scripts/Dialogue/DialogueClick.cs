using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//Source: How to make a Dialogue System in Unity
//        https://www.youtube.com/watch?v=_nRzoTzeyxU

//Source: Unity typing text effect for dialogue | Unity tutorial 2021
//        https://www.youtube.com/watch?v=2I92egFvC80

//Can be assigned to any object/sprite you want to be able to click on to start a dialogue
public class DialogueClick : MonoBehaviour
{
    public Sentence[] Interaction;

    public AudioSources AllAudio;

    public GameObject DialogueBox;

    public string[] ResponseStrings;

    public GameObject[] ResponseButtons;

    private int numInteractions;

    public string identifier;

    public bool Clickable = true;

    //Proximity Abilities enabled
    public bool enableProximityReactions;

    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;

    private bool popped = false;

    // Start is called before the first frame update
    void Start(){
        
        if(identifier == null){
            identifier = "infinite";
        }
    }
       
    //TODO: Update() method that checks if player collider is touching the collider attached to this object
    //and if player pressed space (Input.GetKeyDown(KeyCode.Space))
    void Update(){

        if ( PlayerCollider != null){

            if (enableProximityReactions == true && PlayerCollider.IsTouching(ObjectAreaCollider) && popped == false && Clickable){
                
                numInteractions = (int) typeof(InteractionsCounter).GetField("infinite").GetValue(this);
                

                if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused && PlayerCollider.IsTouching(ObjectAreaCollider)){

                    TriggerDialogue();
            
                    numInteractions++;

                    typeof(InteractionsCounter).GetField(identifier).SetValue(this, numInteractions);

                }
                

            }
            else if (enableProximityReactions == true && !PlayerCollider.IsTouching(ObjectAreaCollider) && popped == true && Clickable){
                popped = false;
            }
        }
    }

    public void OnMouseOver() {
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused && Clickable){
                numInteractions = (int) typeof(InteractionsCounter).GetField(identifier).GetValue(this);
            
            AllAudio.playClickSound();

            TriggerDialogue();
          
            numInteractions++;

            typeof(InteractionsCounter).GetField(identifier).SetValue(this, numInteractions);
        }
    }


    public void TriggerDialogue(){

        if (DialogueBox != null)
            DialogueBox.SetActive(true);


        DialogueBox.GetComponent<DialogueManager>().StartDialogue(Interaction, ResponseStrings, ResponseButtons);
        
    }
   

}

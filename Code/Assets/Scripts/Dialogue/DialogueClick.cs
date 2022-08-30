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
    public Dialogue[] dialog;
    private AudioSource clickSound; //don't want clicksound before audio

    public GameObject HeadsUpDisplay;

    public string[] choices;

    public GameObject[] choiceButtons = new GameObject[3];

    public bool speech;

    public bool fern;

    private int numInteractions;

    public string identifier;

    public bool canClick = true;

    //Proximity Abilities enabled
    public bool enableProximityReactions;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    private bool popped = false;


    // Start is called before the first frame update
    void Start()
    {

        clickSound = GameObject.Find("clickSound").GetComponentInChildren<AudioSource>();
        
        //Option 1: switch case
        if(fern){
            foreach(Dialogue di in dialog){
                di.makeFern();
            }
        }

        if(identifier == null){
            identifier = "infintie";
        }

        if (HeadsUpDisplay != null)
            HeadsUpDisplay.SetActive(false);
    }
       
    //TODO: Update() method that checks if player collider is touching the collider attached to this object
    //and if player pressed space (Input.GetKeyDown(KeyCode.Space))
    void Update(){

        if (enableProximityReactions== true && PlayerCollider.IsTouching(ObjectAreaCollider) && popped == false && canClick)
        {
            if (identifier != null)
                numInteractions = (int) typeof(InteractionsCounter).GetField(identifier).GetValue(this);
            else
                numInteractions = (int) typeof(InteractionsCounter).GetField("infinite").GetValue(this);
            
            if(clickSound!=null)
               // clickSound.Play();


            if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused && FindObjectOfType<DialogueManager>().inConversation == false){

                TriggerDialogue();
          
                if (HeadsUpDisplay != null)
                    HeadsUpDisplay.SetActive(true);

                numInteractions++;

                if (identifier != null)
                    typeof(InteractionsCounter).GetField(identifier).SetValue(this, numInteractions);
                else
                    typeof(InteractionsCounter).GetField("infinite").SetValue(this, numInteractions);

            }
            

        }
        else if (enableProximityReactions == true && !PlayerCollider.IsTouching(ObjectAreaCollider) && popped == true && canClick){
            popped = false;
        }
    }

    public void OnMouseOver() {
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused && canClick){
            if (identifier != null)
                numInteractions = (int) typeof(InteractionsCounter).GetField(identifier).GetValue(this);
            else
                numInteractions = (int) typeof(InteractionsCounter).GetField("infinite").GetValue(this);
            
            if(clickSound!=null)
               clickSound.Play();//adds click sound to broom and mop ect

            TriggerDialogue();
          
            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);

            numInteractions++;

            if (identifier != null)
                typeof(InteractionsCounter).GetField(identifier).SetValue(this, numInteractions);
            else
                typeof(InteractionsCounter).GetField("infinite").SetValue(this, numInteractions);
        }
    }


    public void TriggerDialogue()
    {
        int diCount = dialog.Length - 1;
        if (numInteractions <= diCount)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialog[numInteractions], choices, choiceButtons, speech);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialog[diCount], choices, choiceButtons, speech);
        }
        
    }
   

}

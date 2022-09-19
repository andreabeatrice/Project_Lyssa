using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter106 : MonoBehaviour
{

    public GameObject HeadsUpDisplay;
    public Dialogue[] before_dialog;
    public Dialogue[] after_dialog;

   public AudioSources allAudio;


    public string[] before_choices, after_choices;

    public GameObject[] before_choiceButtons = new GameObject[3];

    public GameObject[] after_choiceButtons = new GameObject[3];

    private int numInteractions;

    public string identifier;

    public bool enableProximityReactions;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    private bool popped = false;
    // Start is called before the first frame update
    void Start()
    {

        //Option 1: switch case
        foreach(Dialogue di in before_dialog){
            di.makeFern();   
        }

        if(identifier == null){
            identifier = "infinite";
        }

        if (HeadsUpDisplay != null)
            HeadsUpDisplay.SetActive(false);
    }
       
    //TODO: Update() method that checks if player collider is touching the collider attached to this object
    //and if player pressed space (Input.GetKeyDown(KeyCode.Space))
    void Update(){

        if (enableProximityReactions== true && PlayerCollider.IsTouching(ObjectAreaCollider) && popped == false )
        {
            if (identifier != null)
                numInteractions = (int) typeof(InteractionsCounter).GetField(identifier).GetValue(this);
            else
                numInteractions = (int) typeof(InteractionsCounter).GetField("infinite").GetValue(this);
            
          //  if(clickSound!=null)
                //clickSound.Play();


            if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused && FindObjectOfType<DialogueManager>().inConversation == false){
                allAudio.playErrorSound();

                if(Globals.StorageRoom == false){
                    TriggerBeforeDialogue();
                }
                else {
                    TriggerAfterDialogue();
                }
                
          
                if (HeadsUpDisplay != null)
                    HeadsUpDisplay.SetActive(true);

                numInteractions++;

                if (identifier != null)
                    typeof(InteractionsCounter).GetField(identifier).SetValue(this, numInteractions);
                else
                    typeof(InteractionsCounter).GetField("infinite").SetValue(this, numInteractions);

            }
            

        }
        else if (enableProximityReactions == true && !PlayerCollider.IsTouching(ObjectAreaCollider) && popped == true ){
            popped = false;
        }
    }

    public void OnMouseOver() {
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused){
            if (identifier != null)
                numInteractions = (int) typeof(InteractionsCounter).GetField(identifier).GetValue(this);
            else
                numInteractions = (int) typeof(InteractionsCounter).GetField("infinite").GetValue(this);
            
            //if(clickSound!=null)
               // clickSound.Play();

            if(Globals.StorageRoom == false){
                TriggerBeforeDialogue();
            }
            else {
                TriggerAfterDialogue();
            }
          
            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);

            numInteractions++;

            if (identifier != null)
                typeof(InteractionsCounter).GetField(identifier).SetValue(this, numInteractions);
            else
                typeof(InteractionsCounter).GetField("infinite").SetValue(this, numInteractions);
        }
    }


    public void TriggerBeforeDialogue()
    {
        int diCount = before_dialog.Length - 1;
        if (numInteractions <= diCount)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(before_dialog[0], before_choices, before_choiceButtons, false);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(before_dialog[1], before_choices, before_choiceButtons, false);
        }
        
    }

    public void TriggerAfterDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(after_dialog[0], after_choices,after_choiceButtons, false);
        
        
    }
}

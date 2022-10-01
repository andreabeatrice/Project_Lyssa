using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room106Entry : MonoBehaviour
{
    public AudioSources allAudio;
    public GameObject HeadsUpDisplay;
    public Dialogue after_dialog;
    public string[] after_choices;
    public GameObject[] after_choiceButtons = new GameObject[3];
    public bool enableProximityReactions;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerCollider.IsTouching(ObjectAreaCollider) && Input.GetKeyDown(KeyCode.Space) && !Globals.paused && FindObjectOfType<DialogueManager>().inConversation == false){
            TriggerAfterDialogue();

            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);
        }

        
    }

    public void OnMouseOver() {
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused && PlayerCollider.IsTouching(ObjectAreaCollider) ){
            TriggerAfterDialogue();

            if (HeadsUpDisplay != null)
                    HeadsUpDisplay.SetActive(true);
        }
    }

    public void TriggerAfterDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(after_dialog, after_choices, after_choiceButtons, false);   
    }
}

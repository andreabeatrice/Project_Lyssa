using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room106Interaction : MonoBehaviour
{
    public AudioSources allAudio;
    public GameObject HeadsUpDisplay;
    public Dialogue before_dialog;
    public string[] before_choices;
    public GameObject[] before_choiceButtons = new GameObject[3];
    public bool enableProximityReactions;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    // Start is called before the first frame update
    void Start()
    {
        before_dialog.makeFern();      
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerCollider.IsTouching(ObjectAreaCollider) && Input.GetKeyDown(KeyCode.Space) && !Globals.paused && FindObjectOfType<DialogueManager>().inConversation == false){
                allAudio.playErrorSound();
                TriggerBeforeDialogue();

                if (HeadsUpDisplay != null)
                    HeadsUpDisplay.SetActive(true);
        }

        
    }

    public void OnMouseOver() {
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused){
            allAudio.playErrorSound();
            TriggerBeforeDialogue();

            if (HeadsUpDisplay != null)
                    HeadsUpDisplay.SetActive(true);
        }
    }

    public void TriggerBeforeDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(before_dialog, before_choices, before_choiceButtons, false);   
    }
}

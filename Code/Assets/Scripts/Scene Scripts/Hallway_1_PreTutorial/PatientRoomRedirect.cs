using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientRoomRedirect : MonoBehaviour
{
    AudioSources allAudio;
    GameObject NoActionChoiceButton;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;

    // Start is called before the first frame update
    void Start()
    {
        allAudio = FindObjectOfType<AudioSources>();
        NoActionChoiceButton = GameObject.Find("basement_agreement");
    }

    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space) && PlayerCollider.IsTouching(ObjectAreaCollider))
            OnMouseDown();
    }

    void OnMouseDown()
    {
        FindObjectOfType<DialogueBoxHandler>().showHUD();
        
        string[] bucketSentences = new string[] {"I should go get cleaning supplies first"};

        Dialogue bucketDialogue = new Dialogue(bucketSentences, "Fern", null);

        FindObjectOfType<DialogueManager>().StartDialogue(bucketDialogue, "Yeah, okay", NoActionChoiceButton, false);

        allAudio.playErrorSound();
    }
}

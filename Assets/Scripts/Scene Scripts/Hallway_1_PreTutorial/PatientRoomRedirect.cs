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
        FindObjectOfType<DialogueBoxHandler>().ShowDialogueBox();
        
        string[] bucketSentences = new string[] {};

        Sentence[] s = new Sentence[]{new Sentence("I should go get cleaning supplies first",1)};

        FindObjectOfType<DialogueManager>().StartDialogue(s, "Yeah, okay", NoActionChoiceButton);

        allAudio.playErrorSound();
    }
}

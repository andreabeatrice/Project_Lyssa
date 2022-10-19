using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientRoomRedirect : MonoBehaviour
{
    AudioSources allAudio;
    GameObject NoActionChoiceButton;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    public GameObject ManagerHolder;



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
        ManagerHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        string[] bucketSentences = new string[] {};

        Sentence[] s = new Sentence[]{new Sentence("I should go get cleaning supplies first",1)};

        ManagerHolder.GetComponent<DialogueManager>().StartDialogue(s);

        allAudio.playErrorSound();
    }
}

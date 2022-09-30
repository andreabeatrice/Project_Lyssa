using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDialogue : MonoBehaviour
{
    public AudioSources AllAudio;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    public GameObject HeadsUpDisplay;
    public Sentence[] DialogueVariable;
    public string[] Choices;
    public GameObject[] ChoiceButtons = new GameObject[3];
    public bool played = false;
    public bool speech;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider.IsTouching(ObjectAreaCollider) && played == false){

            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);

            FindObjectOfType<DialogueAutoplayManager>().StartDialogue(DialogueVariable, Choices, ChoiceButtons, speech);

            played = true;
        }
        else if(!PlayerCollider.IsTouching(ObjectAreaCollider) && played == true){

            played = false;
        }
    }


}

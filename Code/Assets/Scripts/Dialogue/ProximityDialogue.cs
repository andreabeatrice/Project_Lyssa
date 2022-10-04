using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDialogue : MonoBehaviour
{
    public AudioSources AllAudio;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    public GameObject HeadsUpDisplay;
    public Sentence[] DialogueVariable = new Sentence[2];
    public string[] Choices;
    public GameObject[] ChoiceButtons = new GameObject[3];
    public bool played = false;
    public bool speech;

    public bool nurse;

    // Start is called before the first frame update
    void Start()
    {
        if (Globals.blamed_receptionist && !nurse){
            DialogueVariable[0] = new Sentence("We run a very tight ship here, Mrs Pattel. And your incompetence this morning put our entire operation at risk.", null, "Dr Kraus", ColorCodes.kraus);
            DialogueVariable[1] = new Sentence("I'm afraid I'm going to have to ask you to pack up your desk. I want you out of here within the hour.", null, "Dr Kraus", ColorCodes.kraus);
        } 
        else if (!nurse) {
            DialogueVariable[0] = new Sentence("Mrs Pattel, I'm going to need you to speak to the Jackson Laboratory.", null, "Dr Kraus", ColorCodes.kraus);
            DialogueVariable[1] = new Sentence("JAX® Mice have told me that they will no longer ship to us. But I'm so close to my breakthrough!", null, "Dr Kraus", ColorCodes.kraus);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider.IsTouching(ObjectAreaCollider) && played == false){

            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);

            FindObjectOfType<DialogueAutoplayManager>().StartDialogue(DialogueVariable, Choices, ChoiceButtons);

            played = true;
        }

    }


}

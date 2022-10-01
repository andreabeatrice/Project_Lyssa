using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAutoStart : MonoBehaviour
{
    public Sentence[] interaction;

    public GameObject HeadsUpDisplay;

    public string[] choices;

    public GameObject[] choiceButtons = new GameObject[3];

    public bool wait;

    //bool speech: used to determine whether the DialogueManager should play gibberish
    public bool speech;

    public float waitfor;

    // Start(): is called before the first frame update - calls TriggerDialogue() or TriggerDialogueNoWait()
        void Start()
        {
            StartCoroutine(TriggerDialogue());
        }

    //TriggerDialogue(): Waits for 1.5 seconds to be sure that the scene transition is done
        IEnumerator TriggerDialogue()
        {
            
            yield return new WaitForSeconds(waitfor);
            
            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);

            FindObjectOfType<DialogueManager>().StartDialogue(interaction, choices, choiceButtons, speech);
        }

    //TriggerDialogueNoWait(): WaStarts the dialogue immediately
        public void TriggerDialogueNoWait()
        {
            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);

            FindObjectOfType<DialogueManager>().StartDialogue(interaction, choices, choiceButtons, speech);
        }


}

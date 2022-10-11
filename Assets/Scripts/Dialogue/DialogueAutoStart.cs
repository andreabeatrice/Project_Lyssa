using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAutoStart : MonoBehaviour
{
    public Sentence[] Interaction;

    public GameObject DialogueBox;

    public string[] ResponseStrings;

    public GameObject[] ResponseButtons;

    public bool wait;

    public float TimeToWait;

    // Start(): is called before the first frame update - calls TriggerDialogue() or TriggerDialogueNoWait()
        void Start()
        {
            StartCoroutine(TriggerDialogue());
        }

    //TriggerDialogue(): Waits for 1.5 seconds to be sure that the scene transition is done
        IEnumerator TriggerDialogue()
        {
            
            yield return new WaitForSeconds(TimeToWait);
            
            if (DialogueBox != null)
                DialogueBox.SetActive(true);

            FindObjectOfType<DialogueManager>().StartDialogue(Interaction, ResponseStrings, ResponseButtons);
        }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAutoStart_Fight : MonoBehaviour
{
  public Sentence[] interaction;

    public GameObject DialogueBox;

    public string[] ResponseStrings;

    public GameObject[] ResponseButtons;

    public float waitfor;

    private bool willFight = false;
    

    // Start(): is called before the first frame update - calls TriggerDialogue() or TriggerDialogueNoWait()
        void Start()
        {
            StartCoroutine(TriggerDialogue());
        }

        void Update(){   
            if (DialogueBox.activeSelf == true)
                willFight = true;

            if (DialogueBox.activeSelf == false && willFight)
                StartCoroutine(FIGHT());
        }

    //TriggerDialogue(): Waits for 1.5 seconds to be sure that the scene transition is done
        IEnumerator TriggerDialogue()
        {
            
            yield return new WaitForSeconds(waitfor);
            
            if (DialogueBox != null)
                DialogueBox.SetActive(true);

            FindObjectOfType<DialogueManager>().StartDialogue(interaction, ResponseStrings, ResponseButtons);

            
        }

        IEnumerator FIGHT(){
        
            float ttw = (interaction[interaction.Length - 1].Words.ToCharArray().Length * Globals.typingSpeed) + 1;

            yield return new WaitForSeconds(ttw);

            FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_2_Fight", "crossfade_start");

        }

}

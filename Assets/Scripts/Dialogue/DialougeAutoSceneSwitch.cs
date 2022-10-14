using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeAutoSceneSwitch : MonoBehaviour
{

    public Sentence[] interaction;

    public GameObject DialogueBox;

    public string[] ResponseStrings;

    public GameObject[] ResponseButtons;

    public float waitfor = 3f;

    private bool willFight = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        //TriggerDialogue(): Waits for 1.5 seconds to be sure that the scene transition is done
        IEnumerator TriggerDialogue()
        {
            
            yield return new WaitForSeconds(waitfor);
            
            if (DialogueBox != null)
                DialogueBox.SetActive(true);

            FindObjectOfType<DialogueManager>().StartDialogue(interaction);

            
        }

        IEnumerator FIGHT(){
        
            float ttw = (interaction[interaction.Length - 1].Words.ToCharArray().Length * Globals.typingSpeed) + 1;

            yield return new WaitForSeconds(ttw);

            FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_2_Fight", "crossfade_start");

        }
}

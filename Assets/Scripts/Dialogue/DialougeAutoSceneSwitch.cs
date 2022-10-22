using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeAutoSceneSwitch : MonoBehaviour
{

    public Sentence[] interaction;

    public GameObject DialogueBox;

    public string[] ResponseStrings;

    public GameObject[] ResponseButtons;

    public float waitfor = 0.5f;

    private bool willFight = false;

    public string scene;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TriggerDialogue());
    }

    // Update is called once per frame
    void Update()
    {
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

            FindObjectOfType<DialogueManager>().StartDialogue(interaction);

            
        }

        IEnumerator FIGHT(){
        
            float ttw = (interaction[interaction.Length - 1].Words.ToCharArray().Length * Globals.typingSpeed) ;

            yield return new WaitForSeconds(ttw);

            FindObjectOfType<LevelLoader>().LoadNextLevel(scene, "crossfade_start");

        }
}

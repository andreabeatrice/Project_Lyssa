using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAutoStart_Fight : MonoBehaviour
{
  public Sentence[] interaction;

    public GameObject DialogueBox;

    public string[] ResponseStrings;

    public GameObject[] ResponseButtons;

    public GameObject crosshair;

    public float waitfor = 3f;

    private bool willFight = false;

    public Animator PlayerAnimator;
    

    // Start(): is called before the first frame update - calls TriggerDialogue() or TriggerDialogueNoWait()
        void Start()
        {
            if (HelperMethods.CheckInventory("antipsychotic")){
                Sentence[] temp = new Sentence[10];

                for(int i = 0 ; i < 7; i++){
                    temp[i] = interaction[i];
                }

                temp[7] = new Sentence("You do have one last ace up your sleeve, though.");
                temp[8] = new Sentence("Remember that antipsychotic pill you picked up earlier?");
                temp[9] = new Sentence("If you're worried about your insanity levels, this might be a good time to take it.");

                DialogueBox.SetActive(true);

                DialogueBox.GetComponent<DialogueManager>().StartDialogue(temp, ResponseStrings, ResponseButtons);
            }
            else {

                StartCoroutine(TriggerDialogue());
            }
            
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

            DialogueBox.GetComponent<DialogueManager>().StartDialogue(interaction);

            
        }

        IEnumerator FIGHT(){
    
            yield return new WaitForSeconds(2f);

            //FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_2_Fight", "crossfade_start");
            crosshair.SetActive(true);


        }

    public void TakeAntipsychotic(){
        DialogueBox.GetComponent<DialogueBoxHandler>().ClearDialogueBox();
        PlayerAnimator.Play("player_takepill");

        if (Globals.insanity >= 9){
            Globals.insanity -= 5;
            interaction = new Sentence[2];

            interaction[0] = new Sentence("Looks like you made the right choice.");
            interaction[1] = new Sentence("Good luck.");
        }
        else {
            Globals.insanity += 5;

            interaction = new Sentence[2];

            interaction = new Sentence[]{new Sentence("Didn't you read the label of the pills?"), new Sentence("When taken by someone not experiencing a psychotic break, antipsychotics can result in /psychosis-like/ symptoms."), 
                                        new Sentence("Good luck. You'll need it.")};
        }

        StartCoroutine(TriggerDialogue());
    }

    public void DontTakePill(){
        interaction = new Sentence[]{new Sentence("Playing it safe, then."), new Sentence("Fair enough.")};

        StartCoroutine(TriggerDialogue());
    }

}

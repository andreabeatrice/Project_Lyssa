using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptionistScript : MonoBehaviour
{

    public AudioSources AllAudio;

    public GameObject DialogueBoxHolder, Receptionist;
    // Start is called before the first frame update

    Sentence[] convincingDialogue;

    public Collider2D PlayerCollider, ReceptionistCollider;

    public GameObject[] Choices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerCollider.IsTouching(ReceptionistCollider) && Globals.blamed_receptionist == true){
            InteractionsCounter.receptionistInDiningHall = 1;
                this.GetComponent<DialougeAutoSceneSwitch>().enabled = true;
                // convincingDialogue = new Sentence[]{ 
                //     new Sentence("Bold of you to come anywhere /near/ me after getting me fired!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                //     new Sentence("I know you lied to the nurse! And now you've ruined all the careful work we did trying to infiltrate this place!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                //     new Sentence("You deserve to /pay/ for what you did to me!!!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                // };
        }
        else if (PlayerCollider.IsTouching(ReceptionistCollider) && Input.GetKeyDown(KeyCode.Space)){
            OnMouseDown();
        }
    }

    public void OnMouseDown(){


        if (InteractionsCounter.receptionistInDiningHall == 0){

            HelperMethods.ObjectivesDequeue("Find the rats that are cooking something up?");


            InteractionsCounter.receptionistInDiningHall = 1;
            GameObject[] CorrespondingChoices = null;
            string [] CorrespondingResponses = null;
            if (Globals.blamed_receptionist == false && Globals.insanity <= 5){
                convincingDialogue = new Sentence[]{ 
                    new Sentence("Oh! Fern! You frightened me!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("This place is so creepy! If I had my way, I'd never have come to  work here!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("But needs must.", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("You know, Fern, Nurse Tarr came to apologize to me earlier. ", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("She felt guilty for trying to get you to blame me for you being in room 106. ", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("Does that make sense? ", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("Anyway. It would have been easier for you to blame me. In light of that, I feel like I owe you one. ", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("You knew the patient in 106 before she came here, right?", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("Can you keep what I want to tell you a secret?", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                };

                CorrespondingResponses = new string[]{"Actually, I'm busy (+0)","Sure (+0)"};
                CorrespondingChoices = new GameObject[] {Choices[0], Choices[1]};

            }
            else {
                convincingDialogue = new Sentence[]{ 
                    new Sentence("Ugh! Absolutely disgusting!!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("Fern! I thoght you were payed to clean? There are /rats/ in the kitchen!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                    new Sentence("... ", null, "Fern", ColorCodes.fern),
                    new Sentence("Well? Go catch them!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                };
                StartCoroutine(AddObjective());

            }


            DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
            
            DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue,CorrespondingResponses, CorrespondingChoices);
        }
        else{
            Receptionist.GetComponent<CursorManager>().enabled = false;
        }



    }

    public void FernCanKeepASecret(){
         convincingDialogue = new Sentence[]{ 
                new Sentence("Yes, of course!", null, "Fern", ColorCodes.fern),
                new Sentence("Well, you didn't hear this from me, but there's some really shady stuff going down here. Like, the police needed to plant an informant, shady.", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                new Sentence("So, here I am. ", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                new Sentence("I've been trying to infiltrate Kraus's operation, but he just doesn't trust me enough to let me into the basement. ", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                new Sentence("And it's so frustrating! We /know/ there's another entrance to the basement through the Common Room, it's on the building plans.", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                new Sentence("But we can't figure out how to get in. ", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                new Sentence("If he's keeping patient 6... Dahlia... anywhere, it's there.", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
        };

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, "Thank her for the info (+0)", Choices[2]);
    }

    public void FernIsKindOfBusy(){
        convincingDialogue = new Sentence[]{ 
                new Sentence("Well, in that case, at /least/ go do your job. There are rats in the kitchen!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
                new Sentence("...", null, "Fern", ColorCodes.fern),
                new Sentence("Well? Go catch them!", AllAudio.receptionist_voice, "Mrs Pattel", ColorCodes.receptionist),
        };

        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue);

        StartCoroutine(AddObjective());
    }

    public IEnumerator AddObjective(){
        yield return new WaitForSeconds(4f);

        HelperMethods.ObjectivesEnqueue("Catch the rat in the kitchen");
    }

    public void ThanksForTheMemories(){
        HelperMethods.ObjectivesEnqueue("Find the secret entrance to the basement.");
    }
}

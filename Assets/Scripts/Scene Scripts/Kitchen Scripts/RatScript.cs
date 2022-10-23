using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatScript : MonoBehaviour
{

    public Animator RatAnimator;

    public GameObject[] InsaneChoices;
    public GameObject[] RatChoices;

    public AudioSources AllAudio;

    public GameObject DialogueBoxHolder, Rat;
    // Start is called before the first frame update

    Sentence[] convincingDialogue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
         
        Rat.GetComponent<PolygonCollider2D>().enabled = false;
         HelperMethods.ObjectivesDequeue("Find the rats that are cooking something up?");


        if (Globals.insanity >= 5){
            convincingDialogue = new Sentence[]{ 
                new Sentence("This rat... it looks smarter than the rest.", null, "", new Color32(255,255,255,255)),
                new Sentence("You could.......... try to communicate", null, "", new Color32(255,255,255,255))
            };

            //RatAnimator.Play("");

            DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
            DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Speak to the rat (+3)","Try catch it (-1)"}, InsaneChoices);
        }
        else {
            convincingDialogue = new Sentence[]{ 
                new Sentence("You should probably try catch that rat, right?.", null, "", new Color32(255,255,255,255))
            };

            DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
            DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, "Try catch it (-1)", InsaneChoices[1]);
        }

        

    }
    
    public void CatchRat(){
        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ClearDialogueBox();
        RatAnimator.Play("RatRuns");

        StartCoroutine(Death());
        
    }

    public void CommunicateWithTheRat(){
        HelperMethods.ObjectivesDequeue("Speak to the rat in the kitchen.");
        Globals.insanity += 3;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("Really?", null, "", new Color32(255,255,255,255))
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[0], InsaneChoices[1]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Speak to the rat (+1)","Try catch it (+0)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat2(){
        Globals.insanity += 1;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("You're sure?", null, "", new Color32(255,255,255,255))
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[1], InsaneChoices[1]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Speak to the rat (+1)","Try catch it (+0)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat3(){
        Globals.insanity += 1;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("On your head be it.", null, "", new Color32(255,255,255,255)),
                new Sentence("The rat blinks at you meaningfully.", null, "", new Color32(255,255,255,255))
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[2], InsaneChoices[1]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Ask about HER (+1)","Try catch it (last chance)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat4(){
        Globals.insanity += 1;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("Where's the patient from room 106?", AllAudio.fern_voice, "Fern", ColorCodes.fern),
                new Sentence("...", null, "", new Color32(255,255,255,255)),
                new Sentence("...", null, "", new Color32(255,255,255,255)),
                new Sentence("...", null, "", new Color32(255,255,255,255)),
                new Sentence("She never left", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[3], RatChoices[4]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Ask to explain (+3)","Ask where (+1)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat_Elaborate(){
        Globals.insanity += 3;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("What's happening to her? What's happening here?", AllAudio.fern_voice, "Fern", ColorCodes.fern),
                new Sentence("Before Lyssa Psychiatric Instituion was ever conceived of, this property belonged to a wealthy family with many secrets.", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
                new Sentence("Their son discovered secret passages between some rooms, and set up a secret laboratory under ground.", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
                new Sentence("As the family's money drained away with time, he worked to establish the mansion as a private asylum, ", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
                new Sentence("so that he could continue his work away from prying eyes...", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
                new Sentence("...down in the basement that he used to sneak into through the secret passages, when he was meant to be practising his music.", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[6], RatChoices[5]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"How to open passage (+2)","Stop Talking to It (+0)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat_AskWhere(){
        Globals.insanity += 1;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("How can I find her?", AllAudio.fern_voice, "Fern", ColorCodes.fern),
                new Sentence("The answer has been around you all along.", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
                new Sentence("On the subway walls, like the words of the prophet.", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
                new Sentence("Pinned up like a formula.", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
                new Sentence("It announces itself all the time.", AllAudio.ratSqueak, "Rat", ColorCodes.rat),
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[3], RatChoices[5]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Ask it to elaborate (+3)","Stop Talking to It (+0)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat_HowToGetThere(){
        Globals.insanity += 2;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("How can I get to her?", AllAudio.fern_voice, "Fern", ColorCodes.fern),
                new Sentence("Play just four notes. He's a forgetful sort; he usually keeps them stuck up somewhere.", AllAudio.ratSqueak, "Rat", ColorCodes.rat)
        };

        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue);

        StartCoroutine(BackToDiningHall());

        HelperMethods.ObjectivesDequeue("Find the secret entrance to the basement.");

    }

    public void CommunicateWithTheRat_StopTalkingToIt(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("DiningHall_Base", "crossfade_start");
    }

    public void RatTesting(){
        Debug.Log(Globals.insanity);
        Debug.Log("End of conversation");
        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ClearDialogueBox();
    }

    public IEnumerator BackToDiningHall(){
        float TimeToClear = (convincingDialogue[convincingDialogue.Length-1].Words.ToCharArray().Length * Globals.typingSpeed) + 3;
        yield return new WaitForSeconds(TimeToClear);
        FindObjectOfType<LevelLoader>().LoadNextLevel("DiningHall_2_AfterKitchen", "crossfade_start");
    }

    public IEnumerator Death() //each sentence
    {

        yield return new WaitForSeconds(3);
        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();

        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(new Sentence[]{new Sentence("Damn!! Wait- who's there?", AllAudio.fern_voice, "Fern", ColorCodes.fern)});

        //
        FindObjectOfType<AudioSources>().StopAllAudio();
        FindObjectOfType<AudioSources>().playFootsteps();

        //DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(new Sentence[]{new Sentence("Damn!! Wait- who's there?", AllAudio.fern_voice, "Fern", ColorCodes.fern)});

        StartCoroutine(ExperimentationScene());
        
    }

    public IEnumerator ExperimentationScene() //each sentence
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("ExperimentationDeath_CutScene_Kitchen");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room105ChoiceHandler : MonoBehaviour
{

    public Animator otto;

    public AudioSources AllAudio;

    public GameObject[] flames = new GameObject[10];

    public GameObject[] lowInsanitychoices, highInsanityChoices = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResponseToAskingAboutPatients(){
        Globals.insanity += 1;
        Sentence[] convincingDialogue = new Sentence[]{ new Sentence("No No No No No No No No No No If I talk about it they'll take me next that's why they took—", null, "Otto", ColorCodes.patients)};

        Globals.deaths.Add("(1) Cigarettes are against the rules. (2) They're very bad for you. (3) Don't ask people questions that make them uncomfortable.");

        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, "", null);

        otto.Play("otto_smoking_panic");

        StartCoroutine(CatchFire(0));

        StartCoroutine(Dies());

        
    }

    public void ResponseToAskingAboutNote(){
        Sentence[] convincingDialogue = null;
        string[] choices = new string[2];

        if (Globals.insanity < 5){
            convincingDialogue = new Sentence[]{new Sentence("The rats told me they're cooking something up.", null, "Otto", ColorCodes.patients), 
                                                            new Sentence("You... spoke to one of the rats?", null, "Fern", ColorCodes.fern),
                                                            new Sentence("/You/ wouldn't understand. Just like the rest of them. Think I'm insane. Think I'm /dumb/.", null, "Otto", ColorCodes.patients),
                                                            new Sentence("Not gonna talk to you anymore. You're just as mean.", null, "Otto", ColorCodes.patients)};
        
            choices[0] = "Apologize and Leave (+0)";

            if(HelperMethods.CheckInventory("antipsychotic")){
                choices[1] = "Take antipsychotic (+5)";
                lowInsanitychoices[1] = lowInsanitychoices[2];
                lowInsanitychoices[2] = null;

                HelperMethods.InventoryDequeue("antipsychotic");
            }
            else {
                choices[1] = "Make a face at him (+1)";
                lowInsanitychoices[2] = null;
            }
            
        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, choices, lowInsanitychoices);
        }
        else{
            convincingDialogue = new Sentence[]{new Sentence("They've got a rat. She speaks to me sometimes, tell me what's happening.", null, "Otto", ColorCodes.patients), 
                                                            new Sentence("Will she talk to me?", null, "Fern", ColorCodes.fern),
                                                            new Sentence("Dunno. She might. Usually see her when I'm eating.", null, "Otto", ColorCodes.patients)};

            choices[0] = "Thank Otto (-1)";

            FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, choices, highInsanityChoices);

        }

        
        
    }

    public IEnumerator CatchFire(int i){
        
        
        if (i < 10){
            flames[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);

        i += 1;

        StartCoroutine(CatchFire(i));
        
    }

    public IEnumerator Dies(){
        yield return new WaitForSeconds(5f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");
    }

    public void TakeAntipsychoticToIncreaseInsanity(){
        Globals.insanity += 5;
        ResponseToAskingAboutNote();
    }

    public void BackToHallway_Kitchen(){
    Globals.playerPositionOnMap = new Vector2(-48, -8);
       FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_8_Kitchen", "crossfade_start");
       Debug.Log("leaving now...");
    }

    public void InsanityIncreaseExit(){
        Globals.insanity += 1;

        BackToHallway_Kitchen();
    }

    public void InstanityDecreaseExit(){
        Globals.insanity -= 1;
        BackToHallway_Kitchen();
    }
}

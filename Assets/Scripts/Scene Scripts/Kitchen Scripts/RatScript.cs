using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour
{

    public Animator RatAnimator;

    public GameObject[] InsaneChoices;
    public GameObject[] RatChoices;

    public AudioSources AllAudio;

    public GameObject DialogueBoxHolder;
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

        }

        

    }

    public void CommunicateWithTheRat(){
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
                new Sentence("She never left", null, "Rat", ColorCodes.rat),
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[3], RatChoices[4]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Ask it to elaborate (+2)","Ask where (+1)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat_Elaborate(){
        Globals.insanity += 2;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("But why?", AllAudio.fern_voice, "Fern", ColorCodes.fern),
                //new Sentence("Before Lyssa Psychiatric Instituion was ever conceived of, ", null, "Rat", ColorCodes.rat),
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[3], RatChoices[4]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Ask it to elaborate (+2)","Ask where (+1)"}, AddCatchChoice);
    }

    public void CommunicateWithTheRat_AskWhere(){
        Globals.insanity += 1;
        
        convincingDialogue = new Sentence[]{ 
                new Sentence("How can I find her?", AllAudio.fern_voice, "Fern", ColorCodes.fern),
                new Sentence("The answer has been around you all along.", null, "Rat", ColorCodes.rat),
                new Sentence("On the subway walls, like the words of the prophet.", null, "Rat", ColorCodes.rat),
                new Sentence("Pinned up like a formula.", null, "Rat", ColorCodes.rat),
                new Sentence("It announced itself all the time.", null, "Rat", ColorCodes.rat),
        };

        GameObject[] AddCatchChoice = new GameObject[]{RatChoices[3], RatChoices[4]};

        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ShowDialogueBox();
        
        DialogueBoxHolder.GetComponent<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Ask it to elaborate (+2)","Ask where (+1)"}, AddCatchChoice);
    }

    public void RatTesting(){
        Debug.Log(Globals.insanity);
        Debug.Log("End of conversation");
        DialogueBoxHolder.GetComponent<DialogueBoxHandler>().ClearDialogueBox();
    }


}

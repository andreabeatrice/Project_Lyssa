using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonRoom_CH : MonoBehaviour
{

    public AudioSources AllAudio;

    public GameObject[] choices;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callNurse(){
        Globals.insanity -= 1;

        Globals.deaths.Add("Sometimes, you do the right things and you still don't win. This time, you were fired for causing the patients distress.");

        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");

    }

    public void TalkHimDown(){
        Globals.insanity += 2;
        Sentence[] convincingDialogue = new Sentence[]{ new Sentence("C'mon, Otto. Breathe. Breathe. I need you to listen to me.", AllAudio.fern_voice, "Fern", ColorCodes.fern)};

        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, new string[]{"Call the nurse (-1)", "Offer him a cigarette (+1)"}, choices);

    }

    public void Cigarette(){    
        FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();

        Globals.insanity += 1;
        Sentence[] convincingDialogue = new Sentence[]{ new Sentence("Hey, you used to smoke, right? I'll give you my pack right now if you calm down.", AllAudio.fern_voice, "Fern", ColorCodes.fern)};
    

        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue);
        FindObjectOfType<LevelLoader>().LoadNextLevelLong("Room105_Otto", "crossfade_start", 5f);
        
    }

    public IEnumerator to105(){
        yield return new WaitForSeconds(5f);

        
    }

    public void toHallway(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_5_Keycard", "crossfade_start");
    }
}

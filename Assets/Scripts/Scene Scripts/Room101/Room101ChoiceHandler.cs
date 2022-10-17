using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room101ChoiceHandler : MonoBehaviour
{

    
    public AudioSources AllAudio;

    public GameObject[] responses = new GameObject[3];

    public string[] restext;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConvinceHer(){
        //start new dialogue

        Sentence[] convincingDialogue = new Sentence[5];

        byte r = (byte) Random.Range(0, 140);
        byte g = (byte) Random.Range(150, 255);
        Color32 blu1 = new Color32( r, g, 255, 255);

        r = (byte) Random.Range(0, 140);
        g = (byte) Random.Range(150, 255);
        Color32 blu2 = new Color32( r, g, 255, 255);

        r = (byte) Random.Range(0, 140);
        g = (byte) Random.Range(150, 255);
        Color32 blu3 = new Color32( r, g, 255, 255);

        convincingDialogue[0] = new Sentence("Mommy, please. We can't stay here. You have to leave with me.", AllAudio.fern_voice, "Fern", ColorCodes.fern);
        convincingDialogue[1] = new Sentence("Unfortunately, young lady, that is not what will be happening here.", null, "???", blu1);
        convincingDialogue[2] = new Sentence("We're so close to success, you know. These experiments will bring millions to the institution", null, "???", blu2);
        convincingDialogue[3] = new Sentence("And to me, but that's peripheral.", null, "???", blu3);
        convincingDialogue[4] = new Sentence("Think of how much your sacrifice is going to help people like your mother.", null, "???", blu3);

        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, restext, responses);

    }

    public void PickHerUp(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_5_Confrontation", "crossfade_start");
    }

    public void YouWontGetAwayWithIt(){
        Sentence[] convincingDialogue = new Sentence[2];

        
        byte r = (byte) Random.Range(0, 140);
        byte g = (byte) Random.Range(150, 255);
        Color32 blu1 = new Color32( r, g, 255, 255);

        convincingDialogue[0] = new Sentence("You won't get away with this. Someone will come looking.", AllAudio.fern_voice, "Fern", ColorCodes.fern);
        convincingDialogue[1] = new Sentence("My dear, who even knows you're here?", null, "???", blu1);

        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, "", null);

        FindObjectOfType<LevelLoader>().LoadNextLevelLong("ExperimentationDeath_CutScene", "crossfade_start", 5f);
    }

    public void sacrificehuh(){
        Sentence[] convincingDialogue = new Sentence[1];

        convincingDialogue[0] = new Sentence("What do you mean 'sacrifice'?", AllAudio.fern_voice, "Fern", ColorCodes.fern);

        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, "", null);

        FindObjectOfType<LevelLoader>().LoadNextLevelLong("ExperimentationDeath_CutScene", "crossfade_start", 3f);


    }
}

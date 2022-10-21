using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScript : MonoBehaviour
{

    public GameObject fern;
    public Animator FernAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //TESTING 
        Globals.insanity = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrinkMilk(){
        fern.SetActive(true);
        FernAnimator.Play("Player_Drinking_Milk");
        FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();

        Globals.deaths.Add("'No outside food' isn't just a suggestion.");

        StartCoroutine(Dies());

    }

    public IEnumerator Dies(){
        yield return new WaitForSeconds(5f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");
    }

    // public void OnMouseDown()
    // {
    //     byte r = (byte) Random.Range(0, 140);
    //     byte g = (byte) Random.Range(150, 255);
    //     Color32 blu1 = new Color32( r, g, 255, 255);

    //     Sentence[] convincingDialogue = new Sentence[]{ new Sentence("The pot wobbles for a second, before coming crashing down on your head...", null, "", new Color32(255,255,255,255)), new Sentence("You should have quit while you were ahead, Fern.", null, "???", blu1)};

    //     FindObjectOfType<DialogueBoxHandler>().ShowDialogueBox();
        
    //     FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, "", null);

    //     StartCoroutine(Exp());
    // }


    public IEnumerator Exp(){
        yield return new WaitForSeconds(5f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("ExperimentationDeath_CutScene", "crossfade_start");
    }

}

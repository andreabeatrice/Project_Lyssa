using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DeathScene : MonoBehaviour
{
    public TMP_Text causeOfDeath;
    public TMP_Text timeOfDeath;

    //public Dialogue di;

    string causeOfDeath_str, timeOfDeath_str; 


    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(){

        causeOfDeath_str = Globals.deaths.Last();

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){

        causeOfDeath.text = causeOfDeath_str;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(causeOfDeath_str, causeOfDeath));

        StartCoroutine(EndDialogue());

    }

    public IEnumerator TypeSentence(string sentence, TMP_Text box) //each sentence
    {
        box.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            box.text += letter;
            yield return new WaitForSeconds(Globals.typingSpeed);
        }
    }

    public IEnumerator EndDialogue(){
        yield return new WaitForSeconds(5f);

        int timeInS = (int)Globals.playedTime;

        timeOfDeath_str = "You survived for " + timeInS.ToString() + " seconds.";

        timeOfDeath.text = timeOfDeath_str;

        StartCoroutine(TypeSentence(timeOfDeath_str, timeOfDeath));
    }

}
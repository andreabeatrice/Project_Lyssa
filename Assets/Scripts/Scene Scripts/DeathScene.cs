using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class DeathScene : MonoBehaviour
{
    public TMP_Text causeOfDeath;
    public TMP_Text timeOfDeath;
    public AudioSources allAudio;
    public Sprite title1, title2, title3, title4, title5, title6;

    public GameObject title;

    //public Dialogue di;

    string causeOfDeath_str, timeOfDeath_str; 

    public static string path;


    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/player.save";
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(){

        causeOfDeath_str = Globals.deaths.Last();

        if (Globals.deaths.Last().Contains("meditation")){//insane
            allAudio.playInsaneEnding();
        }
        else if (Globals.deaths.Last().Contains("proud")){
            allAudio.playWinSound();
        }
        else if (Globals.deaths.Last().Contains("throw")){//success
            allAudio.playWinSound();
        }
        else {//death
            allAudio.playFailSound();
        }
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

        timeOfDeath_str = "You survived for " + timeInS.ToString() + " seconds playing ";

        timeOfDeath.text = timeOfDeath_str;

        StartCoroutine(TypeSentence(timeOfDeath_str, timeOfDeath));
        StartCoroutine(ShowTitle());
    }

    public void StartGame(){
        if(File.Exists(path)){
            File.Delete(path);
        }

        HelperMethods.ResetGlobals();
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_1_PreTutorial", "crossfade_start");
    }

    public void MainMenu(){
        if(File.Exists(path)){
            File.Delete(path);
        }

        HelperMethods.ResetGlobals();
        FindObjectOfType<LevelLoader>().LoadNextLevel("MainMenu", "crossfade_start");
    }

    public void QuitGame(){
        if(File.Exists(path)){
            File.Delete(path);
        }

        HelperMethods.ResetGlobals();

        Application.Quit();
    }

    public IEnumerator ShowTitle(){
        yield return new WaitForSeconds(2f);

        //switch (Globals.deaths.Last())
        if (Globals.deaths.Last().Contains("meditation")){//insane
            title.GetComponent<Image>().sprite = title2;
        }
        else if (Globals.deaths.Last().Contains("proud")){ // escape no mom
            title.GetComponent<Image>().sprite = title1;
        }
        else if (Globals.deaths.Last().Contains("throw")){//success
            title.GetComponent<Image>().sprite = title5;
        }
        else if (Globals.deaths.Last().Contains("Cigarettes")){//fire
            title.GetComponent<Image>().sprite = title6;
        }
        else if (Globals.deaths.Last().Contains("unite")){//killed by receptionist
            title.GetComponent<Image>().sprite = title4;
        }
        else {
            title.GetComponent<Image>().sprite = title3;//dead
        }
        
    }


}

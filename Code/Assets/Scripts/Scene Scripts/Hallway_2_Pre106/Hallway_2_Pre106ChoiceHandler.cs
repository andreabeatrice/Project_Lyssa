using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hallway_2_Pre106ChoiceHandler : MonoBehaviour
{
    public AudioSources allAudio;

    public Sprite cleanWaterDispenser;

    void Start(){
        Globals.paused = false;
    }

    //removeButtons(): Helper Method- hides all buttons in the scene tagged with "ChoiceButton"
        //tags are set in the inspector
        public void removeButtons()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("ChoiceButton");

            foreach (GameObject go in gos)
            {
                go.SetActive(false);
            }


            FindObjectOfType<DialogueManager>().setConversationStatus(false);

        }

    public void mopitup(){
        Globals.mopped = true;

        allAudio.playMoppingSound();//shouldn't play when coming out of 106
        GameObject.Find("WaterDispenser").GetComponent<Animator>().enabled = false;
        GameObject.Find("WaterDispenser").GetComponent<SpriteRenderer>().sprite = cleanWaterDispenser;
    }

    public void cannotmop(){
        Globals.mopped = false;
    }

    public void enter106(){
        allAudio.playOpenDoor();
        Globals.insanity += 3;
        FindObjectOfType<LevelLoader>().LoadNextLevel("Room106", "crossfade_start");

    }

    public void maybedont_106(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_3_Mouse", "crossfade_start");

    }

}

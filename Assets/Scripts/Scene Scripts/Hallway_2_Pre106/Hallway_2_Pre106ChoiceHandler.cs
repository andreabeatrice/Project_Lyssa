using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hallway_2_Pre106ChoiceHandler : MonoBehaviour
{
    public AudioSources allAudio;

    public Sprite WaterCooler_Sprite;

    public GameObject WaterCooler;

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


        }

    public void mopitup(){
        Globals.MoppedWater = true;

        allAudio.playMoppingSound();//shouldn't play when coming out of 106
        WaterCooler.GetComponent<Animator>().enabled = false;
        WaterCooler.GetComponent<SpriteRenderer>().sprite = WaterCooler_Sprite;
    }

    public void cannotmop(){
        Globals.MoppedWater = false;
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

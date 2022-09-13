using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public GameObject pausepopup;

    public void setVolume(float volume){

        audioMixer.SetFloat("Volume", volume);

        Globals.volume = volume;
        
    }


    public void setTypingSpeed(float ts){
        Debug.Log(ts);
       Globals.typingSpeed = ts;
       //TODO: FOR SHOWING WHOLE SENTENCE: TYPINGSPEED = 0?
        
    }

    public void home(){
        SaveSystem.SavePlayer(true);
        SceneManager.LoadScene("MainMenu");
    }

    public void apply(){
        SaveSystem.SavePlayer(true);
        Debug.Log(Globals.typingSpeed);
        pausepopup.SetActive(false);
    }

    public void invertMouse(bool ticked){
        Debug.Log(Globals.currentScene);


        if (ticked){
            Globals.primaryMouseButton = 1;
            Globals.secondaryMouseButton = 0;
        }
        else {
            Globals.primaryMouseButton = 0;
            Globals.secondaryMouseButton = 1;
        }
    }

    public void help(){
        SceneManager.LoadScene("mainMenu_Help");
    }

    public void settings(){
        SceneManager.LoadScene("mainMenu_Settings");
    }
}

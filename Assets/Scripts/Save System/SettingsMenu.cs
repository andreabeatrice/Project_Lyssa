using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public GameObject pausepopup;

    public AudioMixer musicMixer, SFXMixer;

    public GameObject SettingsPanel;

    public TextMeshProUGUI music, sfx, text;

    void Start(){

        if (text != null)
            text.text = (10 - (Globals.typingSpeed * 100)).ToString();

        if (music != null)
            music.text = ((Globals.MusicVolume/8) +10).ToString();

        if (sfx != null)
            sfx.text = ((Globals.SFXVolume/8) +10).ToString();
        
    }

    public void SetMusicVolume(){

        float volume = float.Parse(music.text);

        volume =  0 - (8 * (10 - volume));

        musicMixer.SetFloat("Volume", volume);

        Globals.MusicVolume = volume;  

    }

    public void LowerMusicText(){
        float v = float.Parse(music.text);

        if (v > 0)
            music.text = (v - 1).ToString();

        SetMusicVolume();
    }

    public void RaiseMusicText(){
        float v = float.Parse(music.text);

        if (v < 10)
            music.text = (v + 1).ToString();

        SetMusicVolume();
    }
    
   public void SetSFXVolume(){

        float volume = float.Parse(sfx.text);

        volume =  0 - (8 * (10 - volume));

        SFXMixer.SetFloat("Volume", volume);

        Globals.SFXVolume = volume;  
    }

    public void LowerSFXText(){
        float v = float.Parse(sfx.text);

        if (v > 0)
            sfx.text = (v - 1).ToString();

        SetSFXVolume();
    }

    public void RaiseSFXText(){
        float v = float.Parse(sfx.text);

        if (v < 10)
            sfx.text = (v + 1).ToString();

        SetSFXVolume();
    }

    public void SetTypingSpeed(){
        float textspeed = float.Parse(text.text);

        textspeed = (10-textspeed)/100;

        Globals.typingSpeed = textspeed;
        
    }

    public void LowerSpeedText(){
        float v = float.Parse(text.text);

        if (v > 0)
            text.text = (v - 1).ToString();

        SetTypingSpeed();

        //dialogue manager start sentence
    }

    public void RaiseSpeedText(){
        float v = float.Parse(text.text);

        if (v < 10)
            text.text = (v + 1).ToString();

        SetTypingSpeed();
    }

    public void ApplyFromMainMenu(){
        SaveSystem.SavePlayer(true);
    }


    public void GoToHelpScreen(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("mainMenu_Help", "crossfade_start");
    }

    public void GoToSettingsScreen(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("mainMenu_Settings", "crossfade_start");
    }

    public void GoToMainMenu(){
        SaveSystem.SavePlayer(true);
        FindObjectOfType<LevelLoader>().LoadNextLevel("MainMenu", "crossfade_start");
    }
}

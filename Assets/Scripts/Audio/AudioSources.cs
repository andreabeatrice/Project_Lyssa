using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSources : MonoBehaviour
{
    public AudioSource click_sound;
    public AudioSource open_door;
    public AudioSource footsteps;
    public AudioSource hallway_sounds;
    public AudioSource receptionist_voice;
    public AudioSource fern_voice;
    public AudioSource background_music;
    public AudioSource menu_background_with_crickets;
    public AudioSource crickets_no_music;
    public AudioSource pick_up_object;
    public AudioSource release_object;
    public AudioSource janitors_closet_background_music;
    public AudioSource close_door;
    public AudioSource vent_drip;
    private AudioSource[] allAudioSources;


    public void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        string scenename = SceneManager.GetActiveScene().name;

        switch(scenename){
            case "MainMenu":
                menu_background_with_crickets.Play();
            break;
            case "Hallway":
                StopAllAudio();
                hallway_sounds.Play();
            break;
            case "Janitors_Closet":
                StopAllAudio();
                janitors_closet_background_music.Play();
                vent_drip.Play();
            break;
            case "mainMenu_Settings":
                crickets_no_music.Play();
            break;
            case "mainMenu_Help":
                crickets_no_music.Play();
            break;
            default:

            break;
        }
    }


    public void playClickSound(){
        click_sound.Play();
    }

     public void StopAllAudio() {
        foreach (AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
 }
}

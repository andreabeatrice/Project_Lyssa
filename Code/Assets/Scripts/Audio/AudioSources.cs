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
    public AudioSource nurse_voice;
    public AudioSource background_music;
    public AudioSource menu_background_with_crickets;
    public AudioSource crickets;
    public AudioSource pick_up_object;
    public AudioSource release_object;
    public AudioSource janitors_closet_background_music;
    public AudioSource close_door;
    public AudioSource vent_dripp;
    public AudioSource page_turn;
    public AudioSource book_close;
    public AudioSource background106;
    public AudioSource mopping_sound;
    public AudioSource error_sound;
    public AudioSource puff;
    public AudioSource drawer_open;
    public AudioSource drawer_close;
    private AudioSource[] allAudioSources;


    public void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        string scenename = SceneManager.GetActiveScene().name;

        switch(scenename){//background noises
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
                vent_dripp.Play();
            break;
            case "mainMenu_Settings":
                StopAllAudio();
                crickets.Play();
            break;
            case "mainMenu_Help":
                StopAllAudio();
                crickets.Play();
            break;
            case "Room106":
                StopAllAudio();
                background106.Play();
                break;
           
            default:

            break;
        }
    }

    public void playClickSound(){//other noises where is the babble method?
       // click_sound = GameObject.Find("clickSound").GetComponentInChildren<AudioSource>();
        click_sound.Play();
    }
    public void playPageTurn()
    {
        page_turn = GameObject.Find("pageTurn").GetComponentInChildren<AudioSource>();
        page_turn.Play();
    }
    public void playBookClose()
    {
        book_close = GameObject.Find("bookClose").GetComponentInChildren<AudioSource>();
        book_close.Play();
    }
    public void playMoppingSound()
    {
        mopping_sound.Play();
    }
    public void playErrorSound()
    {
        error_sound.Play();
    }
    public void playNurseTalking()
    {
        nurse_voice.Play();
    }
    public void playOpenDoor()
    {
       open_door.Play();
    }
    public void playPuff()
    {
       puff.Play();
    }
    public void playDrawerClose()
    {
        drawer_close.Play();
    }
    public void playDrawerOpen()
    {
        drawer_open.Play();
    }
    public void playFootsteps()
    {
       footsteps.Play();
    }

    public void StopAllAudio() {
        foreach (AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
 }
}

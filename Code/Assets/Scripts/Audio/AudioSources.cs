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
    public AudioSource vent_drip;
    public AudioSource page_turn;
    public AudioSource book_close;
    public AudioSource background106;
    public AudioSource intercom;
    public AudioSource mopping_sound;
    public AudioSource error_sound;
    public AudioSource puff;
    public AudioSource drawer_open;
    public AudioSource drawer_close;
    private AudioSource[] allAudioSources;


    public void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();


        foreach(AudioSource sound in allAudioSources){
            switch(sound.name){
                case "click_sound":
                    click_sound = sound;
                break;
                case "open_door":
                    open_door = sound;
                break;
                case "footsteps":
                    footsteps = sound;
                break;
                case "hallway_sounds":
                    hallway_sounds = sound;
                break;
                case "receptionist_voice":
                    receptionist_voice = sound;
                break;
                case "fern_voice":
                    fern_voice = sound;
                break;

                case "nurse_voice":
                    nurse_voice = sound;
                break;
                case "background_music":
                    background_music = sound;
                break;
                case "menu_background_with_crickets":
                    menu_background_with_crickets = sound;
                break;
                case "crickets":
                    crickets = sound;
                break;
                case "pick_up_object":
                    pick_up_object = sound;
                break;
                case "release_object":
                    release_object = sound;
                break;

                case "janitors_closet_background_music":
                    janitors_closet_background_music = sound;
                break;
                case "close_door":
                    close_door = sound;
                break;
                case "vent_drip":
                    vent_drip = sound;
                break;
                case "page_turn":
                    page_turn = sound;
                break;
                case "book_close":
                    book_close = sound;
                break;
                case "background106":
                    background106 = sound;
                break;

                case "intercom":
                    intercom = sound;
                break;
                case "mopping_sound":
                    mopping_sound = sound;
                break;
                case "error_sound":
                    error_sound = sound;
                break;
                case "puff":
                    puff = sound;
                break;
                case "drawer_open":
                    drawer_open = sound;
                break;
                case "drawer_close":
                    drawer_close = sound;
                break;
            }
        }
        
        string scenename = SceneManager.GetActiveScene().name;


        if (scenename.Contains("Room1") && !scenename.Contains("106")){
            background106.Play();
        }



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
                vent_drip.Play();
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
            case "Hallway_Post106":
                StopAllAudio();
                intercom.Play();
                break;

            default:

            break;
        }
    }

    public void playClickSound(){
        click_sound.Play();
    }
    public void playPageTurn()
    {
        page_turn.Play();
    }
    public void playBookClose()
    {
        book_close.Play();
    }
    public void playIntercom()
    {
       intercom.Play();
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

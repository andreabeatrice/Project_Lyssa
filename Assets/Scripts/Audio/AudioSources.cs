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
    public AudioSource nurse_voice_2;
    public AudioSource nurse_voice_3;
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
    public AudioSource mirror_squeak;
    public AudioSource cabinet_Open;
    public AudioSource cabinet_Close;
    public AudioSource glass_Clink;
    public AudioSource basement_Background;
    public AudioSource pickUpBook;
    public AudioSource putDownBook;
    public AudioSource light_Switch;
    public AudioSource footsteps_Concrete;
    public AudioSource dies_irae;

    public AudioSource closeKitchenCupboard;
    public AudioSource openKitchenCupboard;
    public AudioSource punch;
    public AudioSource doublePunch;
    public AudioSource kick;
    public AudioSource fridgeDoorOpening;
    public AudioSource fridgeDoorClosing;
    public AudioSource fridgeBeingOpen;
    public AudioSource fridgeHum;
    public AudioSource pot;
    public AudioSource potsAndPans;
    public AudioSource fightBell;
    public AudioSource tickingTimer;

    public AudioSource metalDrag;
    public AudioSource manHoleDrop;
    public AudioSource boilerRoomBackground;
    public AudioSource burning;
    public AudioSource screamingMale;
    public AudioSource fightBackground;
    public AudioSource panting;
    public AudioSource roadAndBirds;
    public AudioSource newspaperSpin;
    public AudioSource OttoNormal;
    public AudioSource OttoFreak;
    public AudioSource Dahlia;
    public AudioSource DrKrause;
    public AudioSource DrKrause_2;
    public AudioSource DrKrause_3;
    public AudioSource WinSound;
    public AudioSource RadioBackground;
    public AudioSource fan;
    public AudioSource tvStatic;
    public AudioSource basementDoors;
    public AudioSource failSound;
    public AudioSource insaneEnding;
    public AudioSource fernFright;
    public AudioSource syringe;
    public AudioSource painfulBreathing;
    public AudioSource fernFreak;
    public AudioSource kettle;
    public AudioSource beep;

    public AudioSource falling;
    public AudioSource FernFallCry;
    public AudioSource FernGulping;
    public AudioSource ratSqueak;

    private AudioSource[] allAudioSources;
    
        public void StopAllAudio() {
            foreach (AudioSource audioS in allAudioSources) {
                audioS.Stop();
            }
        }

     public void StopAllBabbles(){
        fern_voice.Stop();
        nurse_voice.Stop();
        nurse_voice_2.Stop();
        nurse_voice_3.Stop();

        DrKrause.Stop();
        DrKrause_2.Stop();
        DrKrause_3.Stop();

        receptionist_voice.Stop();
        Dahlia.Stop();
        OttoNormal.Stop();
     }

    public void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();

        foreach(AudioSource sound in allAudioSources){
            switch(sound.name){
                case "click_sound":
                    click_sound = sound;
                break;
                case "dies_irae":
                    dies_irae = sound;
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
                case "nurse_voice_2":
                    nurse_voice_2 = sound;
                break;
                case "nurse_voice_3":
                    nurse_voice_3 = sound;
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
                case "RadioBackground":
                    RadioBackground = sound;
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
                case "mirror_squeak":
                    mirror_squeak = sound;
                    break;
                case "cabinet_Open":
                    cabinet_Open = sound;
                    break;
                case "cabinet_Close":
                    cabinet_Close = sound;
                break;
                 case "light_Switch":
                    light_Switch = sound;
                break;
                 case "pickUpBook":
                    pickUpBook = sound;
                break;
                 case "putDownBook":
                    putDownBook = sound;
                break;
                 case "basement_Background":
                    basement_Background = sound;
                break;
                 case "glass_Clink":
                    glass_Clink = sound;
                break;
                case "footsteps_Concrete":
                    footsteps_Concrete = sound;
                break;
                case "closeKitchenCupboard":
                    closeKitchenCupboard = sound;
                break;
                case "openKitchenCupboard":
                    openKitchenCupboard = sound;
                break;
                case "punch":
                    punch = sound;
                break;
                case "doublePunch":
                    doublePunch = sound;
                break;
                case "kick":
                    kick = sound;
                break;
                case "fridgeDoorClosing":
                    fridgeDoorClosing = sound;
                break;
                case "fridgeDoorOpening":
                    fridgeDoorOpening = sound;
                break;
                case "fridgeBeingOpen":
                    fridgeBeingOpen = sound;
                break;
                case "fridgeHum":
                    fridgeHum = sound;
                break;
                  case "pot":
                    pot = sound;
                break;
                  case "potsAndPans":
                    potsAndPans = sound;
                break;
                case "fightBell":
                    fightBell = sound;
                break;
                case "tickingTimer":
                    tickingTimer = sound;
                break;
                 case "metalDrag":
                    metalDrag = sound;
                break;
                case "manHoleDrop":
                    manHoleDrop = sound;
                break;
                 case "burning":
                    burning = sound;
                break;
                 case "screamingMale":
                    screamingMale = sound;
                break;
                case "fightBackground":
                    fightBackground = sound;
                break;
                case "panting":
                    panting = sound;
                break;
                case "roadAndBirds":
                    roadAndBirds = sound;
                break;
                case "fan":
                    fan = sound;
                break;
                case "tvStactic":
                    tvStatic = sound;
                break;
                case "basementDoors":
                    basementDoors = sound;
                break;
                 case "DrKrause_2":
                    DrKrause_2 = sound;
                break;
                case "DrKrause_3":
                    DrKrause_3 = sound;
                break;
                case "WinSound":
                    WinSound = sound;
                break;
                 case "failSound":
                    failSound = sound;
                break;
                 case "insaneEnding":
                    insaneEnding = sound;
                break;
                case "fernFright":
                    fernFright = sound;
                break;
                case "syringe":
                    syringe = sound;
                break;
                case "painfulBreathing":
                    painfulBreathing= sound;
                break;
                 case "fernFreak":
                    fernFreak= sound;
                break;
                case "kettle":
                    kettle = sound;
                break;
                case "beep":
                    beep = sound;
                break;
                case "falling":
                    falling = sound;
                break;
                case "FernFallCry":
                    FernFallCry=sound;
                break;
                  case "FernGulping":
                    FernGulping=sound;
                break;
                case "ratSqueak":
                    ratSqueak=sound;
                break;
            }
        }
        
        string scenename = SceneManager.GetActiveScene().name;


        if (scenename.Contains("Room1") && !scenename.Contains("106")){
            if(background106!=null)
            {
                background106.time = Random.Range(0.01f, background106.clip.length);
                background106.Play();
            }
        }
         if (scenename.Contains("CommonRoom") || scenename.Contains("Dining")){
             RadioBackground.Play();
        }
       



        switch(scenename){//background noises
            case "MainMenu":
                menu_background_with_crickets.Play();
            break;
            case "mainMenu_Help":
                menu_background_with_crickets.Play();
            break;
            case "mainMenu_Settings":
                menu_background_with_crickets.Play();

            break;
                case "Hallway_1_PreTutorial":
                StopAllAudio();
                hallway_sounds.Play();
            break;
            case "Hallway_2_Pre106":
                StopAllAudio();
                hallway_sounds.Play();
            break;
            case "Hallway_3_Mouse":
                StopAllAudio();
                hallway_sounds.Play();
            break;
            case "Hallway_4_Note":
                StopAllAudio();
                hallway_sounds.Play();
            break;
            case "Hallway_5_Keycard":
                StopAllAudio();
                hallway_sounds.Play();
            break;
            case "Hallway_6_Slip":
                StopAllAudio();
                hallway_sounds.Play();
            break;
            case "Janitors_Closet":
                StopAllAudio();
                janitors_closet_background_music.Play();
                vent_drip.Play();
            break;
            case "Room106":
                //StopAllAudio();
                background106.Play();
                break;
            case "Room106_Post":
                background106.Play();
                break;
            case "Hallway_Post106":
                StopAllAudio();
                intercom.Play();
                break;
            case "Room106_Nurse":
                //StopAllAudio();
                //background106.Play();
                break;
            case "Basement_DarkScript":
                StopAllAudio();
                basement_Background.Play();
                break;
            case "Basement_6_ThroughPiano":
                StopAllAudio();
                basement_Background.Play();
                break;
             case "Basement_1_LitUp":
                StopAllAudio();
                basementDoors.Play();
                basement_Background.Play();
                break;
            case "KrausOffice_1_FromHall":
                StopAllAudio();
                janitors_closet_background_music.Play();
                fan.Play();
                break;
            case "KrausOffice_2_LightSwitch":
                janitors_closet_background_music.Play();
                fan.Play();
                break;
            case "KrausOffice_3_NotePath":
                janitors_closet_background_music.Play();
                fan.Play();
                break;
            case "BoilerRoomNoMom":
                boilerRoomBackground.Play();
                vent_drip.Play();
                break;
            case "BoilerRoomWithMom":
                boilerRoomBackground.Play();
                vent_drip.Play();
                break;
            case "Basement_4_LeavesBoiler":
                basement_Background.Play();
                break;
            case "Room101":
                StopAllAudio();
                fightBackground.Play();
                beep.Play();
                break;
            case "Basement_5_Confrontation":
                fightBackground.Play();
                break;
            case "Basement_2_Fight":
                fightBackground.Play();
                break;
            case "Basement_3_Win":
                StopAllAudio();
                fightBackground.Stop();
                panting.Play();
                basement_Background.Play();
                break;
            case "Kitchen_1_BaseScene":
                kettle.Play();
                fridgeHum.Play();
                break;
            case "Kitchen_2_Empty":
                kettle.Play();
                fridgeHum.Play();
                break;
           
            
            default:
            break;
        }
    }

    public void stopMetalDrag(){
        metalDrag.Stop();
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

    public void playSqueak()
    {
       mirror_squeak.Play();
    }

      public void playCabinet_Open()
    {
       cabinet_Open.Play();
    }
      public void playCabinet_Close()
    {
       cabinet_Close.Play();
    }
      public void playLight_Switch()
    {
       light_Switch.Play();
    }
      public void playPickUpBook()
    {
       pickUpBook.Play();
    }
    public void playPutDownBook()
    {
       putDownBook.Play();
    }
    public void playBasement_Background()
    {
       basement_Background.Play();
    }
    public void playGlass_Clink()
    {
       glass_Clink.Play();
    }
    public void playFootsteps_Concrete()
    {
       footsteps_Concrete.Play();
    }
    public void playOpenKitchenCupboard()
    {
       openKitchenCupboard.Play();
    }
    public void playCloseKitchenCupboard()
    {
       closeKitchenCupboard.Play();
    }
     public void playPunch()
    {
       punch.Play();
    }
     public void playDoublePunch()
    {
       doublePunch.Play();
    }
     public void playKick()
    {
       kick.Play();
    }
    public void playFridgeDoorOpoening()
    {
       fridgeDoorOpening.Play();
    }
    public void playFridgeDoorClosing()
    {
       fridgeDoorClosing.Play();
    }
    public void playFridgeBeingOpen()
    {
       fridgeBeingOpen.Play();
    }
    public void playFridgeHum()
    {
       fridgeHum.Play();
    }
     public void playPotsAndPans()
    {
       potsAndPans.Play();
    }
     public void playPot()
    {
       pot.Play();
    }
     public void playFightBell()
    {
       fightBell.Play();
    }
     public void playTickingTimer()
    {
       tickingTimer.Play();
    }
    
     public void playMetalDrag()
    {
       metalDrag.Play();
    }
     public void playManHoleDrop()
    {
       manHoleDrop.Play();
    }
     public void playBoilerRoomBackground()
    {
       boilerRoomBackground.Play();
    }
      public void playScreamingMale()
    {
       screamingMale.Play();
    }
      public void playBurning()
    {
       burning.Play();
    }
       public void playPanting()
    {
       panting.Play();
    }
       public void playRoadAndBirds()
    {
       roadAndBirds.Play();
    }
    public void playWinSound()
    {
       WinSound.Play();
    }
    public void playNewspaperSpin(){
        newspaperSpin.Play();
    }
     public void playOttoNormal()
    {
       OttoNormal.Play();
    }

     public void playOttoFreak()
    {
       OttoFreak.Play();
    }
     public void playDahlia()
    {
       Dahlia.Play();
    }
     public void playDrKrause()
    {
       DrKrause.Play();
    }
     public void playTVStatic()
    {
       tvStatic.Play();
    }
    public void playInsaneEnding(){
        insaneEnding.Play();
    }
    public void playFailSound(){
        failSound.Play();
    }
    public void playFernFright(){
        fernFright.Play();
    }
    public void playSyringe(){
        syringe.Play();
    }
    public void playPainfulBreathing(){
        painfulBreathing.Play();
    }
     public void playFernFreak(){
        fernFreak.Play();
    }
    public void playDiesIrae(){
        dies_irae.Play();
    }
    public void kettleStop(){
        kettle.Stop();
    }
     public void playFalling(){
        falling.Play();
    }
    public void playFernFallCry(){
        FernFallCry.Play();
    }
    public void playFernGulping(){
        FernGulping.Play();
    }
    public void playRatSqueak(){
        ratSqueak.Play();
    }
   /* public void StopAllBabbles(){
        if(DrKrause!=null)
        {
            DrKrause.Stop();
        }
        if(fer!=null)
        {
            fern.Stop();
        }
        if(OttoFreak!=null)
        {
            ottoFreak.Stop();
        }
        if(ottoNormal!=null)
        {

        }
    }*/




}

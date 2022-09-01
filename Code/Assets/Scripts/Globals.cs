using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is not atteched to any game object or sprite, but rather declares & instantiates global variables that must not change across scenes

public static class Globals
{
   // public static AudioSource clickSound;
    public static int insanity = 0;
    public static Queue<string> inventory = new Queue<string>();
    public static Queue<string> objectives = new Queue<string>();
    public static Vector3 playerPositionOnMap = new Vector3(0, 3, 0);
    public static bool paused = false;

    public static bool canClick = false;

    public static string currentScene;

    //Used to determine whether player has completed the Janitors_Closet scene in the tutorial
    public static bool StorageRoom = false;


    //For mouse inversion
    public static int primaryMouseButton = 0;
    public static int secondaryMouseButton = 1;

    public static float volume;

    public static float typingSpeed = 0.03f;

    public static Color32 fernspeech = new Color32(135, 206, 253, 255);

    
}


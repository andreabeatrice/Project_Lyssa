using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SaveData {

    public int insanity;
    public Queue<string> inventory;
    public Queue<string> objectives;
    public float[] position;

    public int primaryMouseButton;
    public int secondaryMouseButton;

    public string currentScene;

    public bool intro;

    public static float volume;

    public static float typingSpeed;


    public SaveData(){
        intro = InteractionsCounter.intro;

        insanity = Globals.insanity;

        inventory = Globals.inventory;

        objectives = Globals.objectives;

        primaryMouseButton = Globals.primaryMouseButton;

        secondaryMouseButton = Globals.secondaryMouseButton;

        position = new float[3];
        position[0] = Globals.playerPositionOnMap.x;
        position[1] = Globals.playerPositionOnMap.y;
        position[2] = Globals.playerPositionOnMap.z;

        currentScene = SceneManager.GetActiveScene().name;

        volume = Globals.volume;

        typingSpeed = Globals.typingSpeed;
    }

    public SaveData(bool settings){
        intro = InteractionsCounter.intro;

        insanity = Globals.insanity;

        inventory = Globals.inventory;

        objectives = Globals.objectives;

        primaryMouseButton = Globals.primaryMouseButton;

        secondaryMouseButton = Globals.secondaryMouseButton;

        volume = Globals.volume;

        typingSpeed = Globals.typingSpeed;

        currentScene = Globals.currentScene;

        position = new float[3];
        position[0] = Globals.playerPositionOnMap.x;
        position[1] = Globals.playerPositionOnMap.y;
        position[2] = Globals.playerPositionOnMap.z;
    }

    public void AssignData(){
        Globals.insanity = this.insanity;
        Globals.inventory = this.inventory;
        Globals.objectives = this.objectives;

        Globals.primaryMouseButton = this.primaryMouseButton;
        Globals.secondaryMouseButton = this.secondaryMouseButton;

        Globals.playerPositionOnMap = new Vector3(position[0], position[1], position[2]);

        //p.rb.position = Globals.playerPositionOnMap; 
        Globals.currentScene = this.currentScene;

    }

    public void AssignData(PlayerController p){
        InteractionsCounter.intro = intro;
        Globals.insanity = this.insanity;
        Globals.inventory = this.inventory;
        Globals.objectives = this.objectives;

        Globals.primaryMouseButton = this.primaryMouseButton;
        Globals.secondaryMouseButton = this.secondaryMouseButton;

        Globals.playerPositionOnMap = new Vector3(position[0], position[1], position[2]);

        p.rb.position = Globals.playerPositionOnMap; 

    }
}

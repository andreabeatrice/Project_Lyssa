using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    public AudioSource openDoorSound;

    public Animator animator;

    //Proximity Abilities enabled
    public bool enableProximityReactions;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;

    void Update(){

    }


    //OnMouseDown(): if the Collider attached to the object the script is attached to is clicked
    // private void OnMouseOver(){
            
    //     if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused ){
    //             handle();
    //         }
    // }



    public void handle(){
        animator.Play("basement_door_open");
        //openDoorSound.Play();

        if(Globals.LightSwitch == true){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_1_LitUp", "crossfade_start");
        }
        else {
            FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_Dark", "crossfade_start");
        }
    }
}

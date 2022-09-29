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
        if (enableProximityReactions== true && PlayerCollider.IsTouching(ObjectAreaCollider))
        {

            if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused ){
                handle();
            }
            

        }
    }


    //OnMouseDown(): if the Collider attached to the object the script is attached to is clicked
    private void OnMouseOver(){
            
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused ){
                handle();
            }
    }


    public IEnumerator EnterDarkBasement(){
        
        //yield on a new YieldInstruction that waits for 1.5 seconds.
        yield return new WaitForSeconds(1.5f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_Dark", "crossfade_start");

    }

    public void handle(){
        animator.Play("basement_door_open");
        //openDoorSound.Play();
        StartCoroutine(EnterDarkBasement());
    }
}

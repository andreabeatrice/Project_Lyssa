using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class watercoolerdeath : MonoBehaviour
{
    public AudioSources allAudio;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    public Animator watercooler_animator;

    private bool unplayed = true;
    
    //TODO: create a Global solution
    
    Color32 c = new Color32(135, 206, 253, 255);
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Hallway_6_Slip" && unplayed){
            unplayed = false;
            watercooler_animator.Play("Player_WaterCooler_slip");
        }
        else if (SceneManager.GetActiveScene().name != "Hallway_6_Slip" && PlayerCollider.IsTouching(ObjectAreaCollider) && !Globals.mopped)
        {

            FindObjectOfType<LevelLoader>().LoadNextLevel("watercooler_death", "crossfade_start");


        }

        

    }
}

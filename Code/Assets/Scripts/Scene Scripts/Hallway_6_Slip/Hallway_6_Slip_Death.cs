using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hallway_6_Slip_Death : MonoBehaviour
{
    public AudioSources allAudio;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    public Animator watercooler_animator_left, watercooler_animator_right;
    public GameObject WaterCoolerLeft, WaterCoolerRight;

    private bool unplayed = true;
    
    //TODO: create a Global solution
    
    Color32 c = new Color32(135, 206, 253, 255);
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Hallway_6_Slip"){
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                Globals.direction = "left";
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
                Globals.direction = "right";
            }
        }
        if (SceneManager.GetActiveScene().name == "Hallway_6_Slip" && unplayed){
            if (Globals.direction == "right"){
                WaterCoolerLeft.SetActive(false);
                watercooler_animator_right.Play("Player_Slip");

            }
            else {
                WaterCoolerRight.SetActive(false);
                watercooler_animator_left.Play("Player_Slip_Reverse");
            }
            
            unplayed = false;
        }
        if (SceneManager.GetActiveScene().name != "Hallway_6_Slip" && PlayerCollider.IsTouching(ObjectAreaCollider) && !Globals.mopped){
                        
            SceneManager.LoadScene("Hallway_6_Slip");


        }

    }
}

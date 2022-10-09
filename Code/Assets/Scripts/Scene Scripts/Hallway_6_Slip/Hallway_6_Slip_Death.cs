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
        //Determine which direction the player is walking from
        if (SceneManager.GetActiveScene().name != "Hallway_6_Slip" && !Globals.MoppedWater){
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                Globals.direction = "left";
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
                Globals.direction = "right";
            }
        }
        //if player is standing over puddle, change scene to Hallway_6_Slip
        if (SceneManager.GetActiveScene().name != "Hallway_6_Slip" && PlayerCollider.IsTouching(ObjectAreaCollider) && !Globals.MoppedWater){
                        
            SceneManager.LoadScene("Hallway_6_Slip");


        }
        //if the scene is Hallway_6_Slip, play the Player_Slip or Player_Slip_Reverse animation & disable the other
        if (SceneManager.GetActiveScene().name == "Hallway_6_Slip" && unplayed){
            StartCoroutine(PostDeathScene());
            if (Globals.direction == "right"){
                WaterCoolerLeft.SetActive(false);
                watercooler_animator_right.Play("Player_Slip");

            }
            else {
                WaterCoolerRight.SetActive(false);
                watercooler_animator_left.Play("Player_Slip_Reverse");
            }

            Globals.deaths.Add("You slipped on a puddle you didn't mop up and cracked your skull. Maybe try do your job a bit next time?");
            unplayed = false;

            
        }


    }

    public IEnumerator PostDeathScene() //each sentence
    {
        yield return new WaitForSeconds(3f);

        //change scene
        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");
    }
}

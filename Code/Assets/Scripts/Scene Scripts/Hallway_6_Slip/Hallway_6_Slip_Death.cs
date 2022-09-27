using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hallway_6_Slip_Death : MonoBehaviour
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
            Debug.Log(Globals.direction);
            watercooler_animator.Play("Player_Slip");
            unplayed = false;
        }
        if (SceneManager.GetActiveScene().name != "Hallway_6_Slip" && PlayerCollider.IsTouching(ObjectAreaCollider) && !Globals.mopped)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                Globals.direction = "left";
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
                Globals.direction = "right";
            }
            
            SceneManager.LoadScene("Hallway_6_Slip");


        }

    }
}

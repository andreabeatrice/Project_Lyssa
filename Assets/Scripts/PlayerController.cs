using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: TOP DOWN MOVEMENT in Unity!
//        https://www.youtube.com/watch?v=whzomFgjT50



//This class is attached to the Player sprite
public class PlayerController : MonoBehaviour
{
    public float movespeed = 7.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource audiosrc;

    Vector2 movement;


    void Start()
    {
        rb.position = Globals.playerPositionOnMap;
    }

    //public GameObject textBox;

    //reference to RigidBody (motor that moves player), attached to 'Player' game object— assigned by dragging 

    // Update is called once per frame
    void Update()
    {
        //input
        if (!Globals.paused)
        {
            movement.x = Input.GetAxisRaw("Horizontal"); //value between -1 and 1 for left/right & a/d
            movement.y = Input.GetAxisRaw("Vertical"); //value between -1 and 1 for up/down & w/s

            if(animator != null)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }


        }

        Globals.playerPositionOnMap = rb.position;

    }

    void FixedUpdate() //Update is not recommended bc your frame rate changes a lot so your speed could change randomly. FixedUpdate() is called 50 times a second
    {
        //movement
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); //moves rigid body to a new position & collide with anything in the way
                                                                                   //Time.fixedDeltaTime = time since method was last called - keeps movement speed constant

        if (audiosrc != null)
        {
            //if not moving
            if (movement.sqrMagnitude == 0)
            {
                audiosrc.Stop();
            }
            else
            {
                if (!audiosrc.isPlaying)
                    audiosrc.Play();
            }
        }
    
    }



}

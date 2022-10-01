using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanePlayerController : MonoBehaviour
{
   public float movespeed = 7.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource audiosrc;
    public bool frozen = false;

    Vector2 movement;


    void Start()
    {
        rb.position = Globals.playerPositionOnMap;
    }

    //public GameObject textBox;

    //reference to RigidBody (motor that moves player), attached to 'Player' game object� assigned by dragging 

    // Update is called once per frame
    void Update()
    {
        //input
        if (!Globals.paused)
        {
            movement.x = Input.GetAxisRaw("Horizontal") ; //value between -1 and 1 for left/right & a/d
            movement.y = Input.GetAxisRaw("Vertical") ; //value between -1 and 1 for up/down & w/s

            if(animator != null && !frozen)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }
            else {
                //animator.SetFloat("Speed", 0);
            }


        }

        if(frozen){
            audiosrc.Stop();
            animator.SetFloat("Speed", 0);
        }

        Globals.playerPositionOnMap = rb.position;

    }

    void FixedUpdate() //Update is not recommended bc your frame rate changes a lot so your speed could change randomly. FixedUpdate() is called 50 times a second
    {
        if (!frozen)
            rb.MovePosition(rb.position + movement * movespeed * (Time.fixedDeltaTime * Random.Range(-1.0f, 1f)) ); //moves rigid body to a new position & collide with anything in the way
                                                                                   //Time.fixedDeltaTime = time since method was last called - keeps movement speed constant

        if (audiosrc != null && !frozen)
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

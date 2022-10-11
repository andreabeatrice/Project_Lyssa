using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragAnimated : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    public AudioSource dragSound;
    public AudioSource puttingDown;
    public Animator dragAnimator;

    //onmouse drag
    //if mouse direction down
        //play 'open draw' animation
    //else
        //play ' close draw animation
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //Debug.Log(mousePos.y - startPosY);

            if(mousePos.y - startPosY < 0){
                dragAnimator.SetFloat("mouseDirection", (mousePos.y - startPosY));
            }
            else {
                dragAnimator.SetFloat("mouseDirection", (mousePos.y - startPosY));
            }
        }
    }

    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused)
        {
            if(dragSound != null)
                dragSound.Play();
            
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);


            startPosX = mousePos.x -  this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;

        }

    }

    void OnMouseUp()
    {
        if (isBeingHeld){
            if(puttingDown != null)
                puttingDown.Play();


            isBeingHeld = false;
            //disable click
            //this.gameObject.transform.GetComponent<ObjectDrag>().enabled = false;
        }

    }
}

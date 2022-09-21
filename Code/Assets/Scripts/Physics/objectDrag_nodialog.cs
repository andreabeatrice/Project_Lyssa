using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: Unity Tutorial | Clicking and Dragging 2D Sprites
//        https://youtu.be/eUWmiV4jRgU?list=PLal20IszKbo4sfOlqe1431Lx2qGBxfATK


public class objectDrag_nodialog : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    public AudioSource dragSound;
    public AudioSource dropSound;
    public bool canDrag = false;



    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

        }
    }


    void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && canDrag && !Globals.paused)
        {
            if (dragSound != null)
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
            if (dropSound != null)
                dropSound.Play();

            isBeingHeld = false;
        }

    }

}

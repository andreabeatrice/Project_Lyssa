using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: Unity Tutorial | Clicking and Dragging 2D Sprites
//        https://youtu.be/eUWmiV4jRgU?list=PLal20IszKbo4sfOlqe1431Lx2qGBxfATK


public class ObjectDrag : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    public AudioSources allAudio;
    public AudioSource dragSound;
    public AudioSource puttingDown;
    public bool canDrag = false;

    public Sentence[] interactions;
    public GameObject HeadsUpDisplay;

    public string[] choices;

    public GameObject[] choiceButtons = new GameObject[3];

    public bool speech;

    public int numInteractions = 0;


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
            dragSound.Play();
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x -  this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;

            TriggerDialogue();

            if (HeadsUpDisplay != null)
                HeadsUpDisplay.SetActive(true);

            numInteractions++;

        }

    }

    void OnMouseUp()
    {
        if (isBeingHeld){
            puttingDown.Play();
            isBeingHeld = false;
        }

    }

    public void TriggerDialogue()
    {
        HeadsUpDisplay.GetComponent<DialogueManager>().StartDialogue(interactions, choices, choiceButtons);

    }
}

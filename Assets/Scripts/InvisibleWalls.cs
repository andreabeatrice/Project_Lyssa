using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWalls : MonoBehaviour
{

    public Collider2D PlayerCollider, BasementCollider, CommonRoomCollider, DiningHallCollider, KrausOfficeCollider;
    public GameObject Action_DoNothing;
    public bool poppedB, poppedD, poppedR, poppedK;
    public GameObject DialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        poppedB = false;
        poppedD = false;
        poppedR = false;
        poppedK = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BasementCollider != null && PlayerCollider.IsTouching(BasementCollider) && poppedB == false)
        {
            poppedB = true;

            DialogueBox.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("It looks like I need a key card to open this door.", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction);

        }

        if (DiningHallCollider != null && PlayerCollider.IsTouching(DiningHallCollider) && poppedD == false)
        {
            poppedD = true;

            DialogueBox.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("The patients are busy eating. I'll disturb them if I go in now.", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction);

        }

        if (CommonRoomCollider != null && PlayerCollider.IsTouching(CommonRoomCollider) && poppedR == false)
        {
            poppedR = true;

            DialogueBox.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("I'm not supposed to clean here today.", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction);

        }

        if (KrausOfficeCollider != null && PlayerCollider.IsTouching(KrausOfficeCollider) && poppedK == false)
        {
            poppedK = true;

            DialogueBox.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("I'm definitely not allowed into Dr Kraus's office! He doesn't even let anyone else clean it!", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction);

        }

        if (BasementCollider != null &&  !PlayerCollider.IsTouching(BasementCollider) && poppedB == true){
            poppedB = false;
        }

        if (CommonRoomCollider != null && !PlayerCollider.IsTouching(CommonRoomCollider) && poppedR == true){
            poppedR = false;
        }

        if (KrausOfficeCollider != null &&  !PlayerCollider.IsTouching(KrausOfficeCollider) && poppedK == true){
            poppedK = false;
        }

        if (DiningHallCollider != null && !PlayerCollider.IsTouching(DiningHallCollider) && poppedD == true){
            poppedD = false;
        }
        
        
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWalls : MonoBehaviour
{

    public Collider2D playerCollider;
    public Collider2D basementDoorCollider;
    public Collider2D recreationAreaCollider;
    public Collider2D diningHallCollider;
    public Collider2D krauseOfficeCollider;

    public GameObject basement_agreement;

    public bool poppedB, poppedD, poppedR, poppedK;
    public GameObject hud;

    public bool speech;


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
        if (playerCollider.IsTouching(basementDoorCollider) && poppedB == false)
        {
            poppedB = true;

            hud.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("It looks like I need a key card to open this door.", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction,  "Okay", basement_agreement);

        }

        if (playerCollider.IsTouching(diningHallCollider) && poppedD == false)
        {
            poppedD = true;

            hud.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("The patients are busy eating. I'll disturb them if I go in now.", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction,  "Okay", basement_agreement);

        }

        if (playerCollider.IsTouching(recreationAreaCollider) && poppedR == false)
        {
            poppedR = true;

            hud.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("I'm not supposed to clean here today.", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction,  "Okay", basement_agreement);

        }

        if (playerCollider.IsTouching(krauseOfficeCollider) && poppedK == false)
        {
            poppedK = true;

            hud.SetActive(true);

            Sentence[] interaction = new Sentence[] {new Sentence("I'm definitely not allowed into Dr Kraus's office! He doesn't even let anyone else clean it!", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction,  "Okay", basement_agreement);

        }

        if (!playerCollider.IsTouching(basementDoorCollider) && poppedB == true){
            poppedB = false;
        }

        if (!playerCollider.IsTouching(recreationAreaCollider) && poppedR == true){
            poppedR = false;
        }

        if (!playerCollider.IsTouching(krauseOfficeCollider) && poppedK == true){
            poppedK = false;
        }

        if (!playerCollider.IsTouching(diningHallCollider) && poppedD == true){
            poppedD = false;
        }
        
        
    }

   
}

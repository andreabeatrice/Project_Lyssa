using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCoolerReaction : MonoBehaviour
{
    public Collider2D PlayerCollider, ObjectAreaCollider;    

    public bool reactionPlayed = false;

    public GameObject DialogueBox;

    public GameObject Action_CannotMop, Action_MopPuddle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider.IsTouching(ObjectAreaCollider) && !reactionPlayed){
            reactionPlayed = true;

            if(HelperMethods.CheckInventory("Broom")){
                DialogueBox.SetActive(true);
                
                Sentence[] interaction = new Sentence[] {new Sentence("Damn, why didn't I pick the mop?", 1)};

                FindObjectOfType<DialogueManager>().StartDialogue(interaction, "Regret choice (+0)", Action_CannotMop);
            }
            else if (HelperMethods.CheckInventory("Mop")){
                DialogueBox.SetActive(true);
                
                Sentence[] interaction = new Sentence[] {new Sentence("Good thing I didn't choose the broom!", 1)};

                FindObjectOfType<DialogueManager>().StartDialogue(interaction, "Mop it up (+0)", Action_MopPuddle);
            }
            else {
                DialogueBox.SetActive(false);
                return;
            }

        }
        if (!PlayerCollider.IsTouching(ObjectAreaCollider) && reactionPlayed == true){
            reactionPlayed = false;
        }
    }
}

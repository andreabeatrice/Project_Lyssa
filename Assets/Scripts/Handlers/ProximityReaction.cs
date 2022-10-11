using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityReaction : MonoBehaviour
{
    public AudioSources AllAudio;

    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;

    public GameObject DialogueBox;

    public GameObject DoNothing, DecisionMop, DecisionBroom;

    private bool popped = false;

    string[] sentences;
    
    //TODO: create a Global solution
    
    Color32 c = new Color32(135, 206, 253, 255);

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider.IsTouching(ObjectAreaCollider) && popped == false){
            popped = true;

            switch(this.name){
                case "WaterDispenser":
                    foreach (string item in Globals.inventory){
                        if (item.Equals("Broom")){
                                reaction("Damn, why didn't I pick the mop?", "Regret choice (+0)", DecisionBroom);
                            }
                            else if (item.Equals("Mop")){
                                
                                reaction("Good thing I didn't choose the broom!", "Mop it up (+0)", DecisionMop);
                            }
                            else {
                                DialogueBox.SetActive(false);
                                return;
                            }
                    }
                break;
                case "KeepOutTape":
                    reaction("Caution tape seems like a bad sign... maybe I should check on her?", "Continue", DoNothing);
                break;

            }
        }
        if (!PlayerCollider.IsTouching(ObjectAreaCollider) && popped == true){
            popped = false;
        }
    }


    public void reaction(string prox, string react, GameObject btn){
        DialogueBox.SetActive(true);
    
        Sentence[] interaction = new Sentence[] {new Sentence(prox, 1)};

        FindObjectOfType<DialogueManager>().StartDialogue(interaction, react, btn);
    }

}

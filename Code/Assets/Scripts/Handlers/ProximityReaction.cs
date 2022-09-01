using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityReaction : MonoBehaviour
{
    public AudioSources allAudio;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    public GameObject HeadsUpDisplay;
    public GameObject ChoiceButton_none, ChoiceButton_mop, ChoiceButton_broom;

    private bool popped = false;
    string[] sentences;
    
    //TODO: create a Global solution
    
    Color32 c = new Color32(135, 206, 253, 255);

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider.IsTouching(ObjectAreaCollider) && popped == false)
        {
            popped = true;

            switch(this.name){
                case "WaterDispenser":
                    foreach (string item in Globals.inventory)
                    {
                        if (item.Equals("Broom")){
                                reaction("Damn, why didn't I pick the mop?", "Are you even a janitor?", ChoiceButton_broom);
                            }
                            else if (item.Equals("Mop")){
                                
                                reaction("Good thing I didn't choose the broom!", "Mop it up", ChoiceButton_mop);
                            }
                            else {
                                HeadsUpDisplay.SetActive(false);
                                return;
                            }
                    }
                break;
                case "KeepOutTape":
                    reaction("Is SHE okay?? What's going on???", "Continue", ChoiceButton_none);
                break;

            }

                

        }

        if (!PlayerCollider.IsTouching(ObjectAreaCollider) && popped == true){
            popped = false;
        }
    }


    public void reaction(string prox, string react, GameObject btn){
        HeadsUpDisplay.SetActive(true);

        sentences =  new string[] {prox};
                    
        Dialogue dialog = new Dialogue(sentences, "Fern", c);

        FindObjectOfType<DialogueManager>().StartDialogue(dialog, react, btn, false);
        //allAudio.playMoppingSound();//need to move
    }

    public void reaction_extended(string[] prox, string react, GameObject btn){
        HeadsUpDisplay.SetActive(true);
        Dialogue dialog = new Dialogue(prox, "Fern", c);

        FindObjectOfType<DialogueManager>().StartDialogue(dialog, react, btn, false);
    }
}

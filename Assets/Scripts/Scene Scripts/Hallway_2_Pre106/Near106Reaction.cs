using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Near106Reaction : MonoBehaviour
{
    public Collider2D PlayerCollider, ObjectAreaCollider;    

    public bool reactionPlayed = false;

    public GameObject DialogueBox;

    public GameObject Decision_DoNothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider.IsTouching(ObjectAreaCollider) && !reactionPlayed){
            reactionPlayed = true;

            DialogueBox.SetActive(true);
                
            Sentence[] interaction = new Sentence[] {new Sentence("Caution tape seems like a bad sign... maybe I should check on her?", 1)};

            FindObjectOfType<DialogueManager>().StartDialogue(interaction, "", null);

        }
        if (!PlayerCollider.IsTouching(ObjectAreaCollider) && reactionPlayed == true){
            reactionPlayed = false;
        }
    }
}
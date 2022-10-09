using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_3_MouseChoiceHandler : MonoBehaviour
{

    public Sentence[] di;
    public GameObject Decision_Enter106;

    public GameObject DialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        Globals.objectives.Dequeue();
        HelperMethods.ObjectivesEnqueue("Don't get fired");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
            DialogueBox.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(di, "Enter Room 106 (+0)", Decision_Enter106);
        }
    }

    public void enter106(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Room106", "crossfade_start");

    }
}

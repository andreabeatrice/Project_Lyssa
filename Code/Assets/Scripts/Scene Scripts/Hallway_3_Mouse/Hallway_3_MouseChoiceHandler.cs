using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_3_MouseChoiceHandler : MonoBehaviour
{

    public Sentence[] di;
    public GameObject ChoiceBtn;

    public GameObject HeadsUpDisplay;

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
            HeadsUpDisplay.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(di, "Enter Room 106 (+0)", ChoiceBtn);
        }
    }

    public void enter106(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Room106", "crossfade_start");

    }
}

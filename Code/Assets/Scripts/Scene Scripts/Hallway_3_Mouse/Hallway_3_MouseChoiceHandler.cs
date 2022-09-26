using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_3_MouseChoiceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.objectives.Dequeue();
        HelperMethods.ObjectivesEnqueue("Don't get fired");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enter106(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Room106", "crossfade_start");

    }
}

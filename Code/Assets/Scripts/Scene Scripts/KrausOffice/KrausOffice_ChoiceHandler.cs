using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrausOffice_ChoiceHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeaveOffice(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_7_LightSwitch", "crossfade_start");
    }

    public void SheTakesAWhiskeyDrink(){
        Globals.insanity += 1;
    }

    
}

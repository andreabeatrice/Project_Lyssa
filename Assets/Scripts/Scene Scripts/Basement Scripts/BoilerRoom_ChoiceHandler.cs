using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerRoom_ChoiceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscapeNow(){
        Globals.insanity -= 3;
        FindObjectOfType<LevelLoader>().LoadNextLevel("EscapeNoMom", "crossfade_start");
    }

    public void SolveIt(){
        Globals.insanity += 1;
        FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_4_LeavesBoiler", "crossfade_start");
    }

    public void Escape(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Escape", "crossfade_start");
    }
}

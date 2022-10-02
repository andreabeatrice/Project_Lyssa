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
        FindObjectOfType<LevelLoader>().LoadNextLevel("EscapeNoMom", "crossfade_start");
    }

    public void SolveIt(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_1_LitUp", "crossfade_start");
    }
}

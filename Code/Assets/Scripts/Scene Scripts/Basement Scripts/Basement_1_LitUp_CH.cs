using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement_1_LitUp_CH : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void intoBoilerRoom(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("BoilerRoomNoMom", "crossfade_start");
    }

    public void ConvinceHer(){

    }

    public void PickHerUp(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_5_Confrontation", "crossfade_start");
    }
}

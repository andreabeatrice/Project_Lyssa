using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInsanityHallwaySwitch : MonoBehaviour
{

    public Rigidbody2D tarr;
    // Start is called before the first frame update
    void Start()
    {
        if(Globals.insanity >= 17){
            //show insanity overlay - shader?
            // spawn nurse tarr x from fern
            Vector3 tarrPosition = Globals.playerPositionOnMap;
            tarrPosition.y = tarrPosition.y - 2;
            tarr.position = tarrPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.insanity >= 17){

            
            SceneManager.LoadScene("Hallway_8_insanity17");
        }
    }
}

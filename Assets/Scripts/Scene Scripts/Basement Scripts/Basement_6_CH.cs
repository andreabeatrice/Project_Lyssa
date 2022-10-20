using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement_6_CH : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = new Vector2(7.87f, 65.63f);
        Globals.playerPositionOnMap = new Vector2(7.87f, 65.63f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void intoBoilerRoom(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("BoilerRoomNoMom", "crossfade_start");
    }

    public void intoBoilerRoomMom(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("BoilerRoomWithMom", "crossfade_start");
    }


    public void into101(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("Room101", "crossfade_start");
    } 

}

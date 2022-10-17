using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement_1_LitUp_CH : MonoBehaviour
{


    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = new Vector3(0, 3, 0);
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

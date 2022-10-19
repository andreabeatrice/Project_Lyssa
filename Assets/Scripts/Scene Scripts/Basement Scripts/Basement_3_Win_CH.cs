using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basement_3_Win_CH : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = new Vector3(-1.31f, 72.31f, 0f);
        Globals.playerPositionOnMap = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void intoBoilerRoomMom(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("BoilerRoomWithMom", "crossfade_start");
    }

}

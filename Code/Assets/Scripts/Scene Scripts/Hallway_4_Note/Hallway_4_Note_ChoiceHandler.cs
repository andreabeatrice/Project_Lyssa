using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_4_Note_ChoiceHandler : MonoBehaviour
{

public Collider2D PlayerCollider;

    public Collider2D CommonRoom;

    public bool played = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        CheckWhatPlayersTouching();
    }

    public void CheckWhatPlayersTouching()
    {
        if (PlayerCollider.IsTouching(CommonRoom) && played == false ){
            EnterOffice();
            played = true;
        }
    }

    public void EnterOffice(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("CommonRoom_1_NotePath", "crossfade_start");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_4_Note_ChoiceHandler : MonoBehaviour
{

public Collider2D PlayerCollider;

    public Collider2D collider;

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
        if (PlayerCollider.IsTouching(collider) && played == false ){
            EnterOffice();
            played = true;
        }
    }

    public void EnterOffice(){
        FindObjectOfType<LevelLoader>().LoadNextLevel("CommonRoom_base", "crossfade_start");
    }
}

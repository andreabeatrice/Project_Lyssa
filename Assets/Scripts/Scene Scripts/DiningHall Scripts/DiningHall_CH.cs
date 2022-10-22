using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningHall_CH : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D PlayerCollider, HallwayCollider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider.IsTouching(HallwayCollider)){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_10_Piano", "crossfade_start");
        }
    }
}
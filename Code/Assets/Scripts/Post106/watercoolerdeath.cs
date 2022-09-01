using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercoolerdeath : MonoBehaviour
{
    public AudioSources allAudio;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    
    //TODO: create a Global solution
    
    Color32 c = new Color32(135, 206, 253, 255);
    void Update()
    {
        if (PlayerCollider.IsTouching(ObjectAreaCollider))
        {

            FindObjectOfType<LevelLoader>().LoadNextLevel("watercooler_death", "crossfade_start");


        }

    }
}

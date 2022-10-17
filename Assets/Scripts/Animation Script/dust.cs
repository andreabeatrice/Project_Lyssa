using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour
{
    public Animator duster;
    public AudioSources allAudio;

    public Collider2D hitbox;

    void OnMouseDown(){
        duster.SetBool("cleaned", true);

        if (allAudio != null)
            allAudio.puff.Play();

        if (hitbox != null)
            hitbox.enabled = false;
    }
}

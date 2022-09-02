using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour
{
    public Animator duster;
    public AudioSources allAudio;

    void OnMouseDown(){
        duster.SetBool("cleaned", true);
        allAudio.puff.Play();
    }
}

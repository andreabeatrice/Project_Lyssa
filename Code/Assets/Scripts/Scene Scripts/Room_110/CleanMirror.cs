using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanMirror : MonoBehaviour
{
    public AudioSources allAudio;
    public Animator mirror_animator;

    private void OnMouseDown()
    {
        if (!mirror_animator.GetBool("cleaned")){
            allAudio.playSqueak();
            mirror_animator.Play("clean_mirror");
            mirror_animator.SetBool("cleaned", true);
        }
        
    }
}

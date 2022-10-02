using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    public Animator switchboard_animator;
    public AudioSources AllAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        AllAudio.playLight_Switch();
        switchboard_animator.Play("switchboard_greenf");
        Globals.LightSwitch = true;
    }



}

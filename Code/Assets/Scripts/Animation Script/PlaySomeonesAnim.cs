using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlaySomeonesAnim : MonoBehaviour
{
    public Animator body;

    public string animation;


    public void play(){
        body.Play(animation);
    }

}
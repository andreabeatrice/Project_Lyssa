using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlaySomeonesAnim : MonoBehaviour
{
    public Animator body;

    public string animation_name;

    public void Start(){
        StartCoroutine(strt());
    }
    public void play(){
        body.Play(animation_name);
    }

    public IEnumerator strt(){
        yield return new WaitForSeconds(5f);

        //body.Play(animation_name);

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour
{
    public Animator duster;

    void OnMouseDown(){
        duster.SetBool("cleaned", true);
    }
}

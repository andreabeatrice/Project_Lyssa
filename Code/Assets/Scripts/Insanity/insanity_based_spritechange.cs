using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insanity_based_spritechange : MonoBehaviour
{
    public Animator this_animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this_animator.SetInteger("insanityLevel", Globals.insanity);
    }
}

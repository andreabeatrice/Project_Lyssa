using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchboard : MonoBehaviour
{

    public Animator switchboard_animator;

    // Start is called before the first frame update
    public void OnMouseDown()
    {
        switchboard_animator.Play("switchboard_open");
    }
}

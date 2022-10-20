using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public Animator ObjectAnimator;
    public AudioSource PlaySound;
    public string Trigger;

    public string AnimationName;

    public GameObject AnimatedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown(){
        PlaySound.Play();
        Debug.Log("soundsssssssssssssssssssssssssssssss");
        if(Trigger != null){
            if(AnimatedObject != null){
                AnimatedObject.SetActive(true);
            }
            ObjectAnimator.SetTrigger(Trigger);
        }
        else if (AnimationName != null){
            if(AnimatedObject != null){
                AnimatedObject.SetActive(true);
            }
            
            ObjectAnimator.Play(AnimationName);
        }
    }

    public void PlayObjectAnimation(){
         if(Trigger != null){
            if(AnimatedObject != null){
                AnimatedObject.SetActive(true);
            }

            ObjectAnimator.SetTrigger(Trigger);


        }
        else if (AnimationName != null){
            if(AnimatedObject != null){
                AnimatedObject.SetActive(true);
            }
            ObjectAnimator.Play(AnimationName);
        }
    }

    public void ResetAnimation(){
        if (Trigger != null){
            ObjectAnimator.ResetTrigger(Trigger);
        }
    }
}

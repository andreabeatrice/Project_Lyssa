using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrausCollider : MonoBehaviour
{
    public Animator fern, kraus;
    public AudioSources AllAudio;

    public int hit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (hit < 3){
            int move = Random.Range(1,2);

            switch (move){
                case 1:
                    AllAudio.playPunch();
                    kraus.Play("kraus_punch");
                break;
                case 2:
                    AllAudio.playKick();
                    kraus.Play("kraus_kick");
                break;

            }

            hit++;

            FindObjectOfType<FightingCrosshairController>().hit = 0;
        }
        else {
            //change to fern loses
            Debug.Log("He wins!");
            kraus.Play("kraus_punch");
            kraus.Play("kraus_kick");
            fern.Play("player_knockout");
        }
    }
}

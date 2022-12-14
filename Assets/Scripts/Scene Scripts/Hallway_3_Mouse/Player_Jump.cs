using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    public Animator player;

    public AudioSources AllAudio;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.position = Globals.playerPositionOnMap;
        StartCoroutine(waitAndJump());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator waitAndJump(){

        yield return new WaitForSeconds(0.5f);
        player.Play("Player_Jump_Away");
    }

    public void PlayScaredNoise(){
        //@Angela - need to play noise here
    }
}

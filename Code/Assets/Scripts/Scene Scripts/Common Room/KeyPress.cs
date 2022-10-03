using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPress : MonoBehaviour
{
    public AudioSources AllAudio;
    public AudioSource note;

    public TextMeshProUGUI keys; 

    Color32 me;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnMouseDown()
    {
        //AllAudio.StopAllAudio();
        keys.text = keys.text + this.name;
        this.GetComponentInChildren<AudioSource>().Play();
    }

    void OnMouseEnter(){
        me = this.GetComponent<SpriteRenderer>().color;
        this.GetComponent<SpriteRenderer>().color = new Color32(220, 220, 220, 255);
    }

     void OnMouseExit()
    {   
        this.GetComponent<SpriteRenderer>().color = me;
    }
}

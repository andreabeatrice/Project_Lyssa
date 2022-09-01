using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insanity_based_spritechange : MonoBehaviour
{
    public GameObject this_image;

    public Sprite[] variations;

    public int[] switches;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(int i in switches){
            if(Globals.insanity >= i){
                this_image.GetComponent<SpriteRenderer>().sprite = variations[i];
            }
        }
    }
}

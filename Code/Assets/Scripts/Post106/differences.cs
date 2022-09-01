using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class differences : MonoBehaviour
{

    public Sprite cleanWaterDispenser;

    // Start is called before the first frame update
    void Start()
    {
        if(Globals.mopped){
            GameObject.Find("WaterDispenser").GetComponent<Animator>().enabled = false;
            GameObject.Find("WaterDispenser").GetComponent<SpriteRenderer>().sprite = cleanWaterDispenser;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

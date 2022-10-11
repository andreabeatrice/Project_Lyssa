using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCoolerImageHandler : MonoBehaviour
{
    public GameObject WaterCooler_Object;
    public Sprite WaterCooler_Sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Globals.MoppedWater){
            WaterCooler_Object.GetComponent<Animator>().enabled = false;
            WaterCooler_Object.GetComponent<SpriteRenderer>().sprite = WaterCooler_Sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

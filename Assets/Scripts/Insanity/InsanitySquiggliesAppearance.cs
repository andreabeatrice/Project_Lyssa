using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanitySquiggliesAppearance : MonoBehaviour
{

    public GameObject Squigglies; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Globals.insanity > 10){
            byte  alpha = (byte) ((25.5f * Globals.insanity-10));
            Squigglies.GetComponent<Image>().color = new Color32(255, 255, 255, alpha);
        }
        else {
            Squigglies.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityMeter : MonoBehaviour
{
    public GameObject meter_image; 
    public Sprite[] meter_sprites = new Sprite[21];
    
    public bool test;

    // Start is called before the first frame update
    void Start()
    {

        if(test == false)
            meter_image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.StorageRoom)
        {
            meter_image.SetActive(true);
        }
        
        if (Globals.insanity < 0){
            Globals.insanity = 0;
        }
        if (Globals.insanity > 20){
            Globals.insanity = 20;
        }

        switch (Globals.insanity)
        {
            case 0:
                meter_image.GetComponent<Image>().sprite = meter_sprites[0];
                break;
            case 1:
                meter_image.GetComponent<Image>().sprite = meter_sprites[1];
                break;
            case 2:
                meter_image.GetComponent<Image>().sprite = meter_sprites[2];
                break;
            case 3:
                meter_image.GetComponent<Image>().sprite = meter_sprites[3];
                break;
            case 4:
                meter_image.GetComponent<Image>().sprite = meter_sprites[4];
                break;
            case 5:
                meter_image.GetComponent<Image>().sprite = meter_sprites[5];
                break;
            case 6:
                meter_image.GetComponent<Image>().sprite = meter_sprites[6];
                break;
            case 7:
                meter_image.GetComponent<Image>().sprite = meter_sprites[7];
                break;
            case 8:
                meter_image.GetComponent<Image>().sprite = meter_sprites[8];
                break;
            case 9:
                meter_image.GetComponent<Image>().sprite = meter_sprites[9];
                break;
            case 10:
                meter_image.GetComponent<Image>().sprite = meter_sprites[10];
                break;
            case 11:
                meter_image.GetComponent<Image>().sprite = meter_sprites[11];
                break;
            case 12:
                meter_image.GetComponent<Image>().sprite = meter_sprites[12];
                break;
            case 13:
                meter_image.GetComponent<Image>().sprite = meter_sprites[13];
                break;
            case 14:
                meter_image.GetComponent<Image>().sprite = meter_sprites[14];
                break;
            case 15:
                meter_image.GetComponent<Image>().sprite = meter_sprites[15];
                break;
            case 16:
                meter_image.GetComponent<Image>().sprite = meter_sprites[16];
                break;
            case 17:
                meter_image.GetComponent<Image>().sprite = meter_sprites[17];
                break;
            case 18:
                meter_image.GetComponent<Image>().sprite = meter_sprites[18];
                break;
            case 19:
                meter_image.GetComponent<Image>().sprite = meter_sprites[19];
                break;
            case 20:
                meter_image.GetComponent<Image>().sprite = meter_sprites[20];
                break;
        }
    }
}

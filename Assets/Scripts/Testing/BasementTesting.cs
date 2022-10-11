using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementTesting : MonoBehaviour
{
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        count++;

        if (count >= 4){
                HelperMethods.InventoryEnqueue("Broom");
                HelperMethods.InventoryEnqueue("HER Diary");
                HelperMethods.InventoryEnqueue("Nurse's keycard");
                HelperMethods.ObjectivesEnqueue("Don't get fired");
                HelperMethods.ObjectivesEnqueue("Find HER");
                HelperMethods.ObjectivesEnqueue("Investigate the basement");

                Globals.StorageRoom = true;
                Globals.LightSwitch = true;
                

            FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_1_LitUp", "crossfade_start");

            Globals.playerPositionOnMap  = new Vector3(0, 3, 0);


        }
    }
}

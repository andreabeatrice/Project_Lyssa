using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateVariables : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool testing = false;

    private bool check = false;

    public int insane = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)){
                make();
                Debug.Log(testing);
                testing = true;
        }
        else if (testing == true && check == false ){
            make();
        }
    }

    public void make(){
          Globals.StorageRoom = true;
            switch (SceneManager.GetActiveScene().name){
                case "Hallway_2_Pre106":
                    //assign variables
                    HelperMethods.InventoryEnqueue("Broom");
                    HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms.");

                    foreach(string s in Globals.objectives){
                        Debug.Log(s);
                    }
                    foreach(string s in Globals.inventory){
                        Debug.Log(s);
                    }

                    rb.position = new Vector2(-34, -10);
                    check = true;
                break;
                case "Room106":
                    HelperMethods.InventoryEnqueue("Broom");
                    
                    check = true;
                break;
                case "Room106_Nurse":
                    HelperMethods.InventoryEnqueue("Broom");
                    HelperMethods.InventoryEnqueue("Note");
                    
                    check = true;
                break;
                case "Hallway_4_Note":
                    HelperMethods.InventoryEnqueue("Broom");
                    HelperMethods.InventoryEnqueue("HER Diary");
                    HelperMethods.InventoryEnqueue("Note from Otto");
                    HelperMethods.ObjectivesEnqueue("Don't get fired");
                    HelperMethods.ObjectivesEnqueue("Find HER");
                    HelperMethods.ObjectivesEnqueue("Find the note writer");
                    rb.position = new Vector2(-34, -10);
                    check = true;
                break;
                case "Room105_Otto":
                    HelperMethods.InventoryEnqueue("Antipsychotic Pill");
                    
                    check = true;
                break;
                case "Hallway_5_Keycard":
                    HelperMethods.InventoryEnqueue("Broom");
                    HelperMethods.InventoryEnqueue("HER Diary");
                    HelperMethods.InventoryEnqueue("Nurse's keycard");
                    HelperMethods.ObjectivesEnqueue("Don't get fired");
                    HelperMethods.ObjectivesEnqueue("Find HER");
                    HelperMethods.ObjectivesEnqueue("Investigate the basement");
                    rb.position = new Vector2(0, -78);
                    check = true;
                break;
                case "Hallway_7_LightSwitch":
                    HelperMethods.InventoryEnqueue("Broom");
                    HelperMethods.InventoryEnqueue("HER Diary");
                    HelperMethods.ObjectivesEnqueue("Don't get fired");
                    HelperMethods.ObjectivesEnqueue("Find HER");
                    HelperMethods.ObjectivesEnqueue("Turn the basement light on");
                    rb.position = new Vector2(0, -78);
                    check = true;
                    Globals.LightSwitch = true;
                break;
                case "Basement_2_Fight":
                    Globals.insanity = insane;
                break;
                case "Hallway_6_Slip":
                    foreach(string s in Globals.objectives){
                        Globals.objectives.Dequeue();
                    }

                    foreach(string s in Globals.inventory){
                        Globals.inventory.Dequeue();
                    }

                    HelperMethods.InventoryEnqueue("Broom");
                    HelperMethods.InventoryEnqueue("HER Diary");
                    HelperMethods.InventoryEnqueue("Note from Otto");

                    HelperMethods.ObjectivesEnqueue("Find the note writer.");

                    rb.position = new Vector2(-34, -10);
                    check = true;
                break;
            }

    }
}

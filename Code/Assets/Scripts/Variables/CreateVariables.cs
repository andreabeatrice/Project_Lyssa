using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateVariables : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool testing =false;

    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testing == true && check == false){

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOopender_pointandclick : MonoBehaviour
{

        //This is assigned to the UI Text Mesh Pro Text object inventory_body
    public TMP_Text inventoryText;

    //This is assigned to the UI Text Mesh Pro Text object objectives_body
    public TMP_Text objectivesText;

    //This is assigned to the UI game object inventory_and_objectives
    public GameObject inventoryAndObjectives;

    public AudioSource clickSound;

    private bool open = false;

    void Update(){
        if(Input.GetKeyDown(KeyCode.I) && inventoryAndObjectives.activeSelf){
            PopupClose();
        }
        
        if (Input.GetKeyDown(KeyCode.I) && !inventoryAndObjectives.activeSelf){
            PopupOpen();
        }
    }


    public void PopupOpen(){
        clickSound.Play();

        //Resets objectives_body and inventory_body so that the list doesn't repeat
            objectivesText.text = "";
            inventoryText.text = "";

        this.open = true;

        //Loops through each string the the objects Queue and adds it to the objectives_body text box so the player can view it
            foreach (string sentence in Globals.objectives)
            {
                objectivesText.text = objectivesText.text + "* " + sentence + "\n";
            }

            //Loops through each string the the inventory Queue and adds it to the inventory_body text box so the player can view it
            foreach (string sentence in Globals.inventory)
            {
                inventoryText.text = inventoryText.text + "* " + sentence + "\n";
            }

    }

    public void PopupClose(){
        inventoryAndObjectives.SetActive(false);
        this.open = false;
    }
}

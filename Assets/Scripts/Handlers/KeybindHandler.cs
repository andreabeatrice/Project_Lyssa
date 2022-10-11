using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeybindHandler : MonoBehaviour
{

        //This is assigned to the UI Text Mesh Pro Text object inventory_body
    public TMP_Text inventoryText;

    //This is assigned to the UI Text Mesh Pro Text object objectives_body
    public TMP_Text objectivesText;

    //This is assigned to the UI game object inventory_and_objectives
    public GameObject inventoryAndObjectives;

    public AudioSource clickSound;

    public Animator animatorForIO;

    //private bool open = false;
    void Update(){
        if(Input.GetKeyDown(KeyCode.I) && inventoryAndObjectives.activeSelf){
             StartCoroutine(PopupClose());
        }
        
        if (Input.GetKeyDown(KeyCode.I) && !inventoryAndObjectives.activeSelf){
            PopupOpen();
           
        }
    }

    IEnumerator PopupClose()
    {
        animatorForIO.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.4f);
        inventoryAndObjectives.SetActive(false);
    }

    public void PopupOpen(){
         clickSound.Play();

            //If the player has clicked on the Player sprite, it reveals the the UI game object inventory_and_objectives
            inventoryAndObjectives.SetActive(true);

            animatorForIO.SetBool("isOpen", true);

            //Resets objectives_body and inventory_body so that the list doesn't repeat
            objectivesText.text = "";
            inventoryText.text = "";

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

            //open = true;
    }
}

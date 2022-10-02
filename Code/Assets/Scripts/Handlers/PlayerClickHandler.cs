using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//This class is attached to the Player sprite, and it used to open the inventory & objectives lists when the player clicks on Fern
public class PlayerClickHandler : MonoBehaviour
{
    //This is assigned to the UI Text Mesh Pro Text object inventory_body
    public TMP_Text inventoryText;

    //This is assigned to the UI Text Mesh Pro Text object objectives_body
    public TMP_Text objectivesText;

    //This is assigned to the UI game object inventory_and_objectives
    public GameObject inventoryAndObjectives;

    public AudioSource clickSound;

    public Animator animatorForIO;

    private bool open = false;

    GameObject[] gos ;
    TextMeshProUGUI[] texts ;

    // Start is called before the first frame update
    void Start()
    {
        gos = GameObject.FindGameObjectsWithTag("inventoryObject");

        int i = 0;

        foreach(GameObject g in gos){
            texts[i] =  g.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }


        //so that the inventory_and_objectives panel is not always covering the screen
        inventoryAndObjectives.SetActive(false);

        if (Globals.objectives.Count == 0)
            Globals.objectives.Enqueue("You haven't been told to do anything yet. Maybe try talking to people?");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.I) && inventoryAndObjectives.activeSelf){
             StartCoroutine(PopupClose());
        }
        
        if (Input.GetKeyDown(KeyCode.I) && !inventoryAndObjectives.activeSelf){
            PopupOpen();
           
        }
    }

    public void OnMouseOver() {
        if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused && !open)
        {
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

            int i = 0;

            //Loops through each string the the inventory Queue and adds it to the inventory_body text box so the player can view it
            foreach (string sentence in Globals.inventory)
            {
                texts[i].text = sentence;

                //inventoryText.text = inventoryText.text + "* " + sentence + "\n";
                //here
                //make the inventory buttons? only si many items in inventory?
                //next button child.text = this object
                i++;
            }

            open = true;

        }
        else if(Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused && open){
            clickSound.Play();

            //If the player has clicked on the Player sprite, it reveals the the UI game object inventory_and_objectives
            //inventoryAndObjectives.SetActive(true);

            StartCoroutine(PopupClose());

            open = false;
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

            int i = 0;

            //Loops through each string the the inventory Queue and adds it to the inventory_body text box so the player can view it
            foreach (string sentence in Globals.inventory)
            {
                texts[i].text = sentence;

                //inventoryText.text = inventoryText.text + "* " + sentence + "\n";
                //here
                //make the inventory buttons? only si many items in inventory?
                //next button child.text = this object
                i++;
            }

            open = true;
    }



}

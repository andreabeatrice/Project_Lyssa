using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class JanitorsCloset_ChoiceHandler : MonoBehaviour
{

    public GameObject insanityMeter;

    public Button Decision_TakeObject;

    public GameObject mop, broom, rat, LeaveRoom_button;

    public bool firstInteraction = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //take(): The onClick() method for the Janitors_Closet scene 'take' button, which:
        // adds the chosen cleaning tool to the player's inventory
        //removes it from the scene
        //disables the other cleaning implement's onClick() method
        //adds the insanity meter
        //Enables dragging on the bucket
        public void TakeObject(){

            string took = Decision_TakeObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text; // find out which object the player took
            Debug.Log(took);

            if (took.Contains("Broom")){
                HelperMethods.InventoryEnqueue("Broom");

                Destroy(broom);

                mop.GetComponent<PolygonCollider2D>().enabled = false;

            }
            else {
                HelperMethods.InventoryEnqueue("Mop");

                Destroy(mop);

                broom.GetComponent<PolygonCollider2D>().enabled = false;
            }

            FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();

            Globals.StorageRoom = true;
            HelperMethods.ObjectivesDequeue("Go to the storage closet for supplies");
            HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms");

            //Explains the insanity meter to the player
            //Explains dragging     
            string[] bucketSentences = new string[] {"The value next to each choice indicates the insanity level of your choice. If your insanity becomes too high, you might get into trouble...",
                                                    "...but if your insanity is too low, you might not understand what's happening around you.",
                                                    "You can also drag objects to learn more information about them.",
                                                    "Try now by dragging the bucket on the shelf."};

            Sentence [] sentences = new Sentence [4];
            for(int i = 0; i < 4; i++){
                sentences[i] = new Sentence(bucketSentences[i]);
            }
            
            FindObjectOfType<DialogueManager>().StartDialogue(sentences);

            //Enables dragging
            FindObjectOfType<ObjectDrag>().canDrag = true;

            rat.GetComponentInChildren<DialogueClick>().Clickable = true;

        }

    //keepLooking(): The onClick() method for the Janitors_Closet scene 'leave' button, which acts as a "no action" button
        public void KeepLooking(){
            FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
        }

    //PokeRat(): An easter egg - lets the player up their insanity by 1 by poking the rat twice
        public void PokeRat() {
            if (firstInteraction) {
                FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
                Globals.insanity += 1;
                firstInteraction = false;
                DestroyImmediate(rat.GetComponent<PolygonCollider2D>());
            }

        }

    //BackToHall(): When the play is done with the tutorial, this puts the player back in the hall & changes their objective to "Go clean the patients' rooms"
        //also sets Globals.StorageRoom to true, so that the game knows that the player has completed the tutorial, and 
        // (1) doesn't allow the player to keep doing it
        // (2) doesn't show the WelcomeStrings in Welcome.cs again
        public void BackToHall(){
            Globals.StorageRoom = true;
            HelperMethods.ObjectivesDequeue("Go to the storage closet for supplies");
            HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms");
            SceneManager.LoadScene("Hallway_2_Pre106");
        }
}

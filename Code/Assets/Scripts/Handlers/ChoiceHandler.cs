using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//This class is attached to any choice button, and each method is a different button's OnClick() method
public class ChoiceHandler : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioSource closeDoorSound;
    public AudioSources allAudio;

    public GameObject hud;

    public GameObject dialogBox;

    public TMP_Text dialogHeading;

    public TMP_Text dialogBody;

    public Button popUpChoice1, popUpChoice2;

    public bool firstInteraction = true;

    public GameObject insanityMeter;

    public Sprite cleanWaterDispenser;

    void Start(){
        Globals.paused = false;
    }

    //InventoryEnqueue(string item): Helper Method- Takes the name of an item to be added to the inventory & checks if the item is already in the inventory
        //if the item isn't already in the inventory, it adds it to the Globals.inventory queue
        public void InventoryEnqueue(string item)
        {
            foreach (string existingItem in Globals.inventory)
            {
                if (existingItem == item)
                {
                    return;
                }
            }

            Globals.inventory.Enqueue(item);
        }

    //ObjectivesEnqueue(string task): Helper Method- Takes the name of a task to be added to the player's objectives & checks if it's already been added
        //if the task in the list is the "default" task, it replaces that task
        //if the task has already been added, it doesn't add it again
        //if the task has not been added, it adds it to the Globals.objectives queue
        public void ObjectivesEnqueue(string task)
        {
            foreach (string existingTask in Globals.objectives)
            {
                if (existingTask == "You haven't been told to do anything yet. Maybe try talking to people?")
                {
                    Globals.objectives.Dequeue();
                    break;
                }
                if (existingTask == task)
                {
                    return;
                }
            }

            Globals.objectives.Enqueue(task);
        }

        public void ObjectivesDequeue(string completedTask){
                if (Globals.objectives.Peek() == completedTask)
                {
                    Globals.objectives.Dequeue();
                }
        }

    //removeButtons(): Helper Method- hides all buttons in the scene tagged with "ChoiceButton"
        //tags are set in the inspector
        public void removeButtons()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("ChoiceButton");

            foreach (GameObject go in gos)
            {
                go.SetActive(false);
            }


            FindObjectOfType<DialogueManager>().setConversationStatus(false);

        }


    //TutorialObjective1(): The OnClick() method for the response to the receptionist
        public void TutorialObjective1()
        {
            int temp = (int) typeof(InteractionsCounter).GetField("receptionist").GetValue(this);
            
            if (temp == 1)
            {
                ObjectivesEnqueue("Go to the storage closet for supplies");

                hud.SetActive(false);

                FindObjectOfType<DialogueManager>().setConversationStatus(false);

                //Popup saying that the player is about to enter the tutorial, and allow them to skip
                dialogBox.SetActive(true);
                dialogHeading.text = "Tutorial";
                dialogBody.text = "You are about to play through the tutorial. If you'd like to skip it, now's your chance.";

                Time.timeScale = 0f;
                popUpChoice1.onClick.AddListener(PlayTutorial);
                popUpChoice2.onClick.AddListener(SkipTutorial);
                firstInteraction = false;

                hud.transform.GetChild(3).gameObject.SetActive(false);
            }
            else
            {
                FindObjectOfType<DialogueBoxHandler>().clearHUD();
            }


        }

    //PlayTutorial(): The onClick() method if the player chooses to do the tutorial- essentially just unpauses the game
        void PlayTutorial()
        {
            //Debug.Log("It's tutorial time!");

            dialogBox.SetActive(false); 
            Time.timeScale = 1f;
        }

    
    //SkipTutorial(): The onClick() method if the player chooses to skip the tutorial- unpauses the game && opens the Tutorial_Skip scene
        void SkipTutorial()
        {
            //Debug.Log("You have skipped the tutorial!");
            Time.timeScale = 1f;
            SceneManager.LoadScene("Tutorial_Skip");
        }

    //TutorialSkipMop(): The onClick() method that adds the Mop to the player's inventory & corrects their objectives, without them having to play the tutorial
        public void TutorialSkipMop()
        {
            InventoryEnqueue("Mop");
            ObjectivesDequeue("Go to the storage closet for supplies");
            ObjectivesEnqueue("Go clean the patients' rooms");
            SceneManager.LoadScene("Hallway");
            Globals.StorageRoom = true;
        }

    //TutorialSkipBroom(): The onClick() method that adds the broom to the player's inventory & corrects their objectives, without them having to play the tutorial
        public void TutorialSkipBroom()
        {
            InventoryEnqueue("Broom");
            ObjectivesDequeue("Go to the storage closet for supplies");
            ObjectivesEnqueue("Go clean the patients' rooms");
            SceneManager.LoadScene("Hallway");
            Globals.StorageRoom = true;
        }

    //take(): The onClick() method for the Janitors_Closet scene 'take' button, which:
        // adds the chosen cleaning tool to the player's inventory
        //removes it from the scene
        //disables the other cleaning implement's onClick() method
        //adds the insanity meter
        //Enables dragging on the bucket
        public void take()
        {
            Button myBtn = GameObject.Find("take").GetComponent<Button>(); //Find the take button
            string took = myBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text; // find out which object the player took

            GameObject toRemove;

            if (took.Contains("broom"))
            {
                InventoryEnqueue("Broom");

                toRemove = GameObject.Find("broom");

                Destroy(toRemove);

                GameObject.Find("mop").GetComponent<PolygonCollider2D>().enabled = false;

            }
            else
            {
                InventoryEnqueue("Mop");

                toRemove = GameObject.Find("mop");

                Destroy(toRemove);

                GameObject.Find("broom").GetComponent<PolygonCollider2D>().enabled = false;
            }

            GameObject.Find("take").SetActive(false);
            GameObject.Find("leave").SetActive(false);
            insanityMeter.SetActive(true);

            //Explains the insanity meter to the player
            //Explains dragging
            string[] bucketSentences = new string[] {"The value next to each choice indicates the insanity level of your choice. If your insanity becomes too high, you might get into trouble...",
                                                    "...but if your insanity is too low, you might not understand what's happening around you.",
                                                    "You can also drag objects to learn more information about them.",
                                                    "Try now by dragging the bucket on the shelf."};

            //Calls the Dialogue class constructor in order to display the bucketSentences
            Dialogue bucketDialogue = new Dialogue(bucketSentences, null);

            FindObjectOfType<DialogueManager>().StartDialogue(bucketDialogue, "", null, false);

            //Enables dragging
            FindObjectOfType<ObjectDrag>().canDrag = true;

            GameObject.Find("Rat").GetComponentInChildren<DialogueClick>().canClick = true;

        }

    //keepLooking(): The onClick() method for the Janitors_Closet scene 'leave' button, which acts as a "no action" button
        public void keepLooking()
        {
            FindObjectOfType<DialogueBoxHandler>().clearHUD();
        }

    //BackToHall(): When the play is done with the tutorial, this puts the player back in the hall & changes their objective to "Go clean the patients' rooms"
        //also sets Globals.StorageRoom to true, so that the game knows that the player has completed the tutorial, and 
        // (1) doesn't allow the player to keep doing it
        // (2) doesn't show the WelcomeStrings in Welcome.cs again
    
        public void BackToHall()
        {
            
            Globals.StorageRoom = true;
            ObjectivesDequeue("Go to the storage closet for supplies");
            ObjectivesEnqueue("Go clean the patients' rooms");
            closeDoorSound.Play();
            SceneManager.LoadScene("Hallway");
        }

    //ratChoice(): An easter egg - lets the player up their insanity by 1 by poking the rat twice
        public void ratChoice()
        {
            if (firstInteraction)
            {
                FindObjectOfType<DialogueBoxHandler>().clearHUD();
                Globals.insanity += 1;
                firstInteraction = false;
                DestroyImmediate(GameObject.Find("Rat").GetComponent<PolygonCollider2D>());
            }

        }

    public void enter106(){
        allAudio.playOpenDoor();
        Globals.insanity += 3;
        FindObjectOfType<LevelLoader>().LoadNextLevel("Room106", "crossfade_start");

    }

    public void mopitup(){
        allAudio.playMoppingSound();
        GameObject.Find("WaterDispenser").GetComponent<Animator>().enabled = false;
        GameObject.Find("WaterDispenser").GetComponent<SpriteRenderer>().sprite = cleanWaterDispenser;
    }


    




}

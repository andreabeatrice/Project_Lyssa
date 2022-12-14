using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//This class is attached to any choice button, and each method is a different button's OnClick() method
public class ChoiceHandler : MonoBehaviour
{
    //public AudioSource clickSound;
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

    //TutorialObjective1(): The OnClick() method for the response to the receptionist
        public void TutorialObjective1()
        {
            int temp = (int) typeof(InteractionsCounter).GetField("receptionist").GetValue(this);
            
            if (temp == 1)
            {
                HelperMethods.ObjectivesEnqueue("Go to the storage closet for supplies");

                hud.SetActive(false);

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
                FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
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
            HelperMethods.InventoryEnqueue("Mop");
            HelperMethods.ObjectivesDequeue("Go to the storage closet for supplies");
            HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms");
            SceneManager.LoadScene("Hallway");
            Globals.StorageRoom = true;
        }

    //TutorialSkipBroom(): The onClick() method that adds the broom to the player's inventory & corrects their objectives, without them having to play the tutorial
        public void TutorialSkipBroom()
        {
            HelperMethods.InventoryEnqueue("Broom");
            HelperMethods.ObjectivesDequeue("Go to the storage closet for supplies");
            HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms");
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
                HelperMethods.InventoryEnqueue("Broom");

                toRemove = GameObject.Find("broom");

                Destroy(toRemove);

                GameObject.Find("mop").GetComponent<PolygonCollider2D>().enabled = false;

            }
            else
            {
                HelperMethods.InventoryEnqueue("Mop");

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

            Sentence [] sentences = new Sentence [4];
            for(int i = 0; i < 4; i++){
                sentences[i] = new Sentence(bucketSentences[i]);
            }
            
            FindObjectOfType<DialogueManager>().StartDialogue(sentences, "", null);

            //Enables dragging
            FindObjectOfType<ObjectDrag>().canDrag = true;

            GameObject.Find("Rat").GetComponentInChildren<DialogueClick>().Clickable = true;

        }

    //keepLooking(): The onClick() method for the Janitors_Closet scene 'leave' button, which acts as a "no action" button
        public void keepLooking()
        {
            FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
        }

    //BackToHall(): When the play is done with the tutorial, this puts the player back in the hall & changes their objective to "Go clean the patients' rooms"
        //also sets Globals.StorageRoom to true, so that the game knows that the player has completed the tutorial, and 
        // (1) doesn't allow the player to keep doing it
        // (2) doesn't show the WelcomeStrings in Welcome.cs again
    
        public void BackToHall()
        {
            
            Globals.StorageRoom = true;
            HelperMethods.ObjectivesDequeue("Go to the storage closet for supplies");
            HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms");
            closeDoorSound.Play();
            SceneManager.LoadScene("Hallway_2_Pre106");
        }

    //ratChoice(): An easter egg - lets the player up their insanity by 1 by poking the rat twice
        public void ratChoice()
        {
            if (firstInteraction)
            {
                FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
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
        Globals.MoppedWater = true;

        allAudio.playMoppingSound();//shouldn't play when coming out of 106
        GameObject.Find("WaterDispenser").GetComponent<Animator>().enabled = false;
        GameObject.Find("WaterDispenser").GetComponent<SpriteRenderer>().sprite = cleanWaterDispenser;
    }

    public void cannotmop(){
        Globals.MoppedWater = false;
    }


    




}

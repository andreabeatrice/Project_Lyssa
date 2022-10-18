using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Hallway_1_PreTutorialChoiceHandler : MonoBehaviour
{
    
    public GameObject DialogueBox;

    public GameObject dialogBox;

    public TMP_Text dialogHeading;

    public TMP_Text dialogBody;

    public Button popUpChoice1, popUpChoice2;
    public bool firstInteraction = true;

    void Start(){
        Globals.paused = false;
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

        }

    //TutorialObjective1(): The OnClick() method for the response to the receptionist
        public void TutorialObjective1()
        {
            int temp = (int) typeof(InteractionsCounter).GetField("receptionist").GetValue(this);
            
            if (temp == 1)
            {
                HelperMethods.ObjectivesEnqueue("Go to the janitor's closet for supplies");

                //

                FindObjectOfType<PauseMenu>().PauseForPopup();
                

                DialogueBox.SetActive(false);

                firstInteraction = false;

                //Popup saying that the player is about to enter the tutorial, and allow them to skip
                dialogBox.SetActive(true);
                dialogHeading.text = "Tutorial";
                dialogBody.text = "You are about to play through the tutorial. If you'd like to skip it, now's your chance.";

                popUpChoice1.onClick.AddListener(PlayTutorial);
                popUpChoice2.onClick.AddListener(SkipTutorial);

            }
            else
            {
                FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
            }


        }

    //PlayTutorial(): The onClick() method if the player chooses to do the tutorial- essentially just unpauses the game
        public void PlayTutorial()
        {
            //Debug.Log("It's tutorial time!");

            dialogBox.SetActive(false); 
            Time.timeScale = 1f;
            Globals.paused = false;
        }

    
    //SkipTutorial(): The onClick() method if the player chooses to skip the tutorial- unpauses the game && opens the Tutorial_Skip scene
        public void SkipTutorial()
        {
            //Debug.Log("You have skipped the tutorial!");
            Time.timeScale = 1f;
            SceneManager.LoadScene("Tutorial_Skip");
        }
}

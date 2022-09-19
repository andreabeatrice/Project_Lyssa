using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Hallway_2_Pre106ChoiceHandler : MonoBehaviour
{
    
    public GameObject HeadsUpDisplay;

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


            FindObjectOfType<DialogueManager>().setConversationStatus(false);

        }

}

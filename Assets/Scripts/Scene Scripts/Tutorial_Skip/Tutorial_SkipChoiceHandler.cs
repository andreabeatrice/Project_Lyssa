using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Tutorial_SkipChoiceHandler : MonoBehaviour
{
    //TutorialSkipMop(): The onClick() method that adds the Mop to the player's inventory & corrects their objectives, without them having to play the tutorial
        public void TutorialSkipMop()
        {
            HelperMethods.InventoryEnqueue("Mop");
            HelperMethods.ObjectivesDequeue("Go to the storage closet for supplies");
            HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms");
            SceneManager.LoadScene("Hallway_2_Pre106");
            Globals.StorageRoom = true;
        }

    //TutorialSkipBroom(): The onClick() method that adds the broom to the player's inventory & corrects their objectives, without them having to play the tutorial
        public void TutorialSkipBroom()
        {
            HelperMethods.InventoryEnqueue("Broom");
            HelperMethods.ObjectivesDequeue("Go to the storage closet for supplies");
            HelperMethods.ObjectivesEnqueue("Go clean the patients' rooms");
            SceneManager.LoadScene("Hallway_2_Pre106");
            Globals.StorageRoom = true;
        }
}

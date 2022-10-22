using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiningHall_CH : MonoBehaviour
{
    // Start is called before the first frame update

    public Collider2D PlayerCollider, HallwayCollider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCollider != null && HallwayCollider != null && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            if (PlayerCollider.IsTouching(HallwayCollider) && SceneManager.GetActiveScene().name == "DiningHall_2_AfterKitchen"){
                FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_10_Piano", "crossfade_start");
            }
            if (PlayerCollider.IsTouching(HallwayCollider) &&  HelperMethods.CheckObjectives("Find the secret entrance to the basement.")){
                FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_10_Piano", "crossfade_start");
            }

            if (PlayerCollider.IsTouching(HallwayCollider) && SceneManager.GetActiveScene().name == "DiningHall_Base"){
                FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_9_Kitchen", "crossfade_start");
            }

            if (PlayerCollider.IsTouching(HallwayCollider) && SceneManager.GetActiveScene().name == "DiningHall_3_KeycardPath"){
                FindObjectOfType<LevelLoader>().LoadNextLevel("Hallway_5_Keycard", "crossfade_start");
            }
        }

    }

    public void OnMouseDown(){
        if (this.name == "Kitchen Doors" && SceneManager.GetActiveScene().name == "DiningHall_Base"){
            FindObjectOfType<LevelLoader>().LoadNextLevel("Kitchen_1_BaseScene", "crossfade_start");
        }
    }
}

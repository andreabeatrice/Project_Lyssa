using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room109_LoadData : MonoBehaviour
{
    private GameObject pillow, poster;
    private GameObject[] drawers;
    // Start is called before the first frame update
    void Start()
    {
        pillow = GameObject.FindGameObjectsWithTag("moveable_object")[0];
        Room_109_SaveData.pillow = new MoveableObject(pillow);
        drawers = GameObject.FindGameObjectsWithTag("draw");
        poster = GameObject.FindGameObjectsWithTag("dust")[0];
        Room_109_SaveData.poster = new MoveableObject(poster);
        //TODO: poster

        if (Room_109_SaveData.visited == false){
            int i = 0;

            foreach (GameObject go in drawers)
            {
                Room_109_SaveData.drawers[i] = new MoveableObject(go);
                Debug.Log(Room_109_SaveData.drawers[i].ToString());
                i++;
            }

            Room_109_SaveData.visited = true;
            
        }
        else {
            pillow.transform.position = Room_109_SaveData.pillow.position; 

            foreach (GameObject go in drawers)
            {
                for (int i = 0; i < drawers.Length; i++){
                    if (go.name == Room_109_SaveData.drawers[i].name){
                        //go.transform.position = Room_109_SaveData.dust[i].position;

                        if (Room_109_SaveData.drawers[i].state){ //opened == true
                            //go.SetActive(false);
                            go.GetComponent<Animator>().SetFloat("mouseDirection", -5);
                        }

                    }
                }
            }

        }
    }

    void Update()
    {
        Room_109_SaveData.pillow.position = pillow.transform.position;

        foreach (GameObject go in drawers){
            for (int i = 0; i < drawers.Length; i++){
                if (go.name == Room_109_SaveData.drawers[i].name){
                    if (go.GetComponent<Animator>().GetFloat("mouseDirection") < 0){
                        Room_109_SaveData.drawers[i].state = true;
                    }
                    else {
                        Room_109_SaveData.drawers[i].state = false;
                    }
                    
                }
            }
        }
    }


}
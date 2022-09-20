using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room108_LoadData : MonoBehaviour
{
    private GameObject[] moveables;
    private GameObject[] drawers;
    // Start is called before the first frame update
    void Start()
    {
        moveables = GameObject.FindGameObjectsWithTag("moveable_object");
        drawers = GameObject.FindGameObjectsWithTag("draw");

        if (Room_108_SaveData.visited == false){
            int i = 0;

            foreach (GameObject go in moveables)
            {
                Room_108_SaveData.moveables[i] = new MoveableObject(go);
                Debug.Log(Room_108_SaveData.moveables[i].ToString());
                i++;
            }

             i = 0;
            foreach (GameObject go in drawers)
            {
                Room_108_SaveData.drawers[i] = new MoveableObject(go);
                Debug.Log(Room_108_SaveData.drawers[i].ToString());
                i++;
            }

            Room_108_SaveData.visited = true;
            
        }
        else {
            foreach (GameObject go in moveables)
            {
                for (int i = 0; i < moveables.Length; i++){
                    if (go.name == Room_108_SaveData.moveables[i].name){
                        go.transform.position = Room_108_SaveData.moveables[i].position;
                    }
                }
            }

            foreach (GameObject go in drawers)
            {
                for (int i = 0; i < drawers.Length; i++){
                    if (go.name == Room_108_SaveData.drawers[i].name){
                        //go.transform.position = Room_108_SaveData.dust[i].position;

                        if (Room_108_SaveData.drawers[i].state){ //opened == true
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
        foreach (GameObject go in moveables){
            for (int i = 0; i < moveables.Length; i++){
                if (go.name == Room_108_SaveData.moveables[i].name){
                    Room_108_SaveData.moveables[i].position = go.transform.position;
                }
             }
        }

        foreach (GameObject go in drawers){
            for (int i = 0; i < drawers.Length; i++){
                if (go.name == Room_108_SaveData.drawers[i].name){
                    if (go.GetComponent<Animator>().GetFloat("mouseDirection") < 0){
                        Room_108_SaveData.drawers[i].state = true;
                    }
                    else {
                        Room_108_SaveData.drawers[i].state = false;
                    }
                    
                }
            }
        }
    }


}
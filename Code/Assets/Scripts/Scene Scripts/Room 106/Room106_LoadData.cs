using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room106_LoadData : MonoBehaviour
{
    private GameObject[] moveables, drawers, dusts;
    // Start is called before the first frame update
    void Start()
    {
        moveables = GameObject.FindGameObjectsWithTag("moveable_object");
        drawers = GameObject.FindGameObjectsWithTag("draw");
        dusts = GameObject.FindGameObjectsWithTag("dust");

        if (Room_106_SaveData.visited == false){
            int i = 0;

            foreach (GameObject go in moveables)
            {
                Room_106_SaveData.moveables[i] = new MoveableObject(go);
                Debug.Log(Room_106_SaveData.moveables[i].ToString());
                i++;
            }

             i = 0;
            foreach (GameObject go in drawers)
            {
                Room_106_SaveData.drawers[i] = new MoveableObject(go);
                Debug.Log(Room_106_SaveData.drawers[i].ToString());
                i++;
            }

             i = 0;
            foreach (GameObject go in dusts)
            {
                Room_106_SaveData.dust[i] = new MoveableObject(go);
                Debug.Log(Room_106_SaveData.dust[i].ToString());
                i++;
            }

            Room_106_SaveData.visited = true;
            
        }
        else {
            foreach (GameObject go in moveables)
            {
                for (int i = 0; i < moveables.Length; i++){
                    if (go.name == Room_106_SaveData.moveables[i].name){
                        go.transform.position = Room_106_SaveData.moveables[i].position;
                    }
                }
            }

            foreach (GameObject go in dusts)
            {
                for (int i = 0; i < dusts.Length; i++){
                    if (go.name == Room_106_SaveData.dust[i].name){
                        //go.transform.position = Room_106_SaveData.dust[i].position;

                        if (Room_106_SaveData.dust[i].state){ //cleaned == true
                            //
                            go.GetComponent<Animator>().SetBool("cleaned", true);
                            go.SetActive(false);
                        }
                    }
                }
            }

            foreach (GameObject go in drawers)
            {
                for (int i = 0; i < drawers.Length; i++){
                    if (go.name == Room_106_SaveData.drawers[i].name){
                        //go.transform.position = Room_106_SaveData.dust[i].position;

                        if (Room_106_SaveData.drawers[i].state){ //opened == true
                            //go.SetActive(false);
                            go.GetComponent<Animator>().SetFloat("mouseDirection", -5);
                        }

                    }
                }
            }

        }
    }

}

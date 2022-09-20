using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room102_LoadData : MonoBehaviour
{
    private GameObject[] moveables, drawers, dusts;
    // Start is called before the first frame update
    void Start()
    {
        moveables = GameObject.FindGameObjectsWithTag("moveable_object");
        drawers = GameObject.FindGameObjectsWithTag("draw");
        dusts = GameObject.FindGameObjectsWithTag("dust");

        if (Room_102_SaveData.visited == false){
            int i = 0;

            foreach (GameObject go in moveables)
            {
                Room_102_SaveData.moveables[i] = new MoveableObject(go);
                Debug.Log(Room_102_SaveData.moveables[i].ToString());
                i++;
            }

            Room_102_SaveData.visited = true;
            
        }
        else {

            foreach (GameObject go in moveables)
            {
                for (int i = 0; i < moveables.Length; i++){
                    if (go.name == Room_102_SaveData.moveables[i].name){
                        go.transform.position = Room_102_SaveData.moveables[i].position;
                    }
                }
            }

        }
    }

    void Update()
    {
        foreach (GameObject go in moveables){
            for (int i = 0; i < moveables.Length; i++){
                if (go.name == Room_102_SaveData.moveables[i].name){
                    Room_102_SaveData.moveables[i].position = go.transform.position;
                }
             }
        }
    }
}

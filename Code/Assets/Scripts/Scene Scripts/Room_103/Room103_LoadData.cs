using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room103_LoadData : MonoBehaviour
{
    private GameObject pillow;
    private GameObject[] drawers;
    // Start is called before the first frame update
    void Start()
    {
        drawers = GameObject.FindGameObjectsWithTag("draw");
        pillow = GameObject.FindGameObjectsWithTag("moveable_object")[0];

        if (Room_103_SaveData.visited == false){

            Room_103_SaveData.pillow = new MoveableObject(pillow);

            int i = 0;
            foreach (GameObject go in drawers)
            {
                Room_103_SaveData.drawers[i] = new MoveableObject(go);
                Debug.Log(Room_103_SaveData.drawers[i].ToString());
                i++;
            }

            Room_103_SaveData.visited = true;
            
        }
        else {

            pillow.transform.position = Room_103_SaveData.pillow.position;

            foreach (GameObject go in drawers)
            {
                for (int i = 0; i < drawers.Length; i++){
                    if (go.name == Room_103_SaveData.drawers[i].name){
                        //go.transform.position = Room_103_SaveData.dust[i].position;

                        if (Room_103_SaveData.drawers[i].state){ //opened == true
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
        Room_103_SaveData.pillow.position = pillow.transform.position;

        foreach (GameObject go in drawers){
            for (int i = 0; i < drawers.Length; i++){
                if (go.name == Room_103_SaveData.drawers[i].name){
                    if (go.GetComponent<Animator>().GetFloat("mouseDirection") < 0){
                        Room_103_SaveData.drawers[i].state = true;
                    }
                    else {
                        Room_103_SaveData.drawers[i].state = false;
                    }
                    
                }
            }
        }
    }
}

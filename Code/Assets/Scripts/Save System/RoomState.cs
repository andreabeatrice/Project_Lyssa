using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] moveables;
        moveables = GameObject.FindGameObjectsWithTag("moveable_object");

        foreach (GameObject go in moveables)
        {
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Source: Topdown 2D RPG In Unity - 06 Camera Follow
//        https://www.youtube.com/watch?v=GOQV688wbU0 

//This class is attached to the Main Camera, and allows the camera to "follow" the target across the screen
public class CameraController : MonoBehaviour
{
    //The Player sprite is assigned to this value so that the camera follows it
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}

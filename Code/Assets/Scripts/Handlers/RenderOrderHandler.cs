using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: Control Sprite Rendering Order (Which 2D Objects Show in Front) | Unity 2018 Tutorial
//        https://www.youtube.com/watch?v=t1UwAGFLmrk

//This class is attached to the GlobalHandlers game object, and is used to correctly order the sprites in the scene
//It is what enables the Player sprite to appear behind another sprite when it is higher on the y axis, and in front of
//the same sprite if it is lower on the y axis
public class RenderOrderHandler : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Creates an array of every sprite in the scene
        SpriteRenderer[] r = FindObjectsOfType<SpriteRenderer>();

        //Loops through the array, and assigns each sprite renderer the 'level' in which it should render its sprite 
        //Value multiplies by -1 in order to ensure that sprites with a negative y value (further down the y axis) 
        //are in fact rendered before the sprites that are higher than them.

        foreach(SpriteRenderer renderer in r)
        {
            if(renderer.tag.Contains("rnd"))
            //childObject.transform.parent.gameObject
            renderer.sortingOrder = (int)(renderer.transform.position.y * -1);
        }

        //tag.Contains(string name)
    }
}

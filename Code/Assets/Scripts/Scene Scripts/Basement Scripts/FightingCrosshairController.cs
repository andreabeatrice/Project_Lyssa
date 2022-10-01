using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCrosshairController : MonoBehaviour
{

    public Collider2D KrausBody;

    public Rigidbody2D crosshair;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn(){
        //KrausBody
        //Get an x value between KrausBody.bounds.Center.x + KrausBody.bounds.Extent.x and KrausBody.bounds.Center.x - KrausBody.bounds.Extent.x
        //Get an y value between KrausBody.bounds.Center.y + KrausBody.bounds.Extent.y and KrausBody.bounds.Center.y - KrausBody.bounds.Extent.y
        //Set the rigid body position to that value

        float x = Random.Range((KrausBody.bounds.center.x - KrausBody.bounds.extents.x), (KrausBody.bounds.center.x + KrausBody.bounds.extents.x));
        float y = Random.Range((KrausBody.bounds.center.y - KrausBody.bounds.extents.y), (KrausBody.bounds.center.y + KrausBody.bounds.extents.y));
    
        Debug.Log(x);
        Debug.Log(y);
    }
}

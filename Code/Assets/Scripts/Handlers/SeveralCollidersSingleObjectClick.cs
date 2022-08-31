using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeveralCollidersSingleObjectClick : MonoBehaviour
{
    public GameObject thisObject;
    public Collider2D[] objectsColliders;


    // Start is called before the first frame update
    void Start()
    {
        objectsColliders = thisObject.GetComponentsInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //USE SUB-GAMEOBJECTS INSTEAD
}

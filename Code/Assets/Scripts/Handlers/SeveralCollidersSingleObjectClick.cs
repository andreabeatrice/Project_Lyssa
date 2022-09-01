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

    void OnMouseDown(){
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Debug.Log(objectsColliders[1].bounds);
        Debug.Log(mousePos);

        foreach(Collider2D item in objectsColliders){
            if(mousePos.x <= (item.bounds.center.x + 0.5) && mousePos.x >= (item.bounds.center.x - 0.5)){
                //if object has 

                 if(item.GetComponent<DialogueClick>() != null && item.GetComponent<DialogueClick>().canClick == true){
                    item.GetComponent<DialogueClick>().TriggerDialogue();
                 }
            }
           

        }
    }



}

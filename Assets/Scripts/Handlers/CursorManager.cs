using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    //if you want it private do:
    [SerializeField]
    Texture2D cursor;

    

    public void OnMouseEnter()
    {

        if (this.GetComponentInChildren<ObjectDrag>()){
            if (this.GetComponentInChildren<ObjectDrag>().canDrag){
                Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            }
            else {
                return;
            }
        }
        else if (this.GetComponentInChildren<DialogueClick>()){
            if (this.GetComponentInChildren<DialogueClick>().Clickable){
                Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            }
            else {
                return;
            }
        }
        else if (this.GetComponentInChildren<objectDrag_nodialog>()){
            if (this.GetComponentInChildren<objectDrag_nodialog>().canDrag){
                Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            }
            else {
                return;
            }
        }
        else {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        }
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        
        //FindObjectOfType<DialogueManager>().setConversationStatus(false);
    }


}

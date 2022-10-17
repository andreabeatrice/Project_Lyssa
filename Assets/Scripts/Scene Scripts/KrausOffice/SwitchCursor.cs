using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCursor : MonoBehaviour
{
    [SerializeField]
    Texture2D cursor;


    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //FindObjectOfType<DialogueManager>().setConversationStatus(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchboard : MonoBehaviour
{
    [SerializeField]
    Texture2D cursor;

    public Animator switchboard_animator;

    private bool open = false;
    private bool flipped = false;

    public AudioSources AllAudio;

    // Start is called before the first frame update
    public void OnMouseDown()
    {

        if (!open && this.name.Contains("Object - Switchboard")){
            switchboard_animator.SetTrigger("Change");
            open = true;
        } 
        else if (!flipped && this.name == "Switch"){
            switchboard_animator.SetTrigger("Change");
            flipped = true;
            Globals.LightSwitch = true;
        }  
    }

    public void OnMouseEnter()
    {
        if (!flipped && this.name == "Switch"){
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        }
    }

    public void OnMouseExit()
    {
        
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //FindObjectOfType<DialogueManager>().setConversationStatus(false);
    }

    public void PlaySwitchFlipNoise(){
        AllAudio.playLight_Switch();
    }

}

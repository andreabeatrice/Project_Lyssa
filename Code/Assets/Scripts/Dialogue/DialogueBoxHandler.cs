using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: How to make a Dialogue System in Unity
//        https://www.youtube.com/watch?v=_nRzoTzeyxU


public class DialogueBoxHandler : MonoBehaviour
{
    public GameObject HeadsUpDisplay;
    

    public void ClearDialogueBox()
    {
        GameObject[] gos;

        gos = GameObject.FindGameObjectsWithTag("ChoiceButton");

        HeadsUpDisplay.SetActive(false);

        foreach (GameObject go in gos){
            go.SetActive(false);
        }

    }

    public void ClearChoiceButtons(){
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("ChoiceButton");

        foreach (GameObject go in gos)
        {
            go.SetActive(false);
        }
    }

    public void RemoveHeadsUpDisplayAfterXTime(float f){
        StartCoroutine(ClearDialogueBoxAfter(f));
    }

    IEnumerator ClearDialogueBoxAfter(float flt)
        {
            yield return new WaitForSeconds(flt);
            
            ClearDialogueBox();
        }

    public void ShowDialogueBox(){
        HeadsUpDisplay.SetActive(true);
    }
}

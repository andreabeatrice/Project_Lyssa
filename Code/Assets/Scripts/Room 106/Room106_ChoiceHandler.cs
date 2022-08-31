using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room106_ChoiceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keep_antipsychotics(){

        HelperMethods.InventoryEnqueue("antipsychotic pill");

        GameObject.Find("Pill").SetActive(false);

        FindObjectOfType<DialogueBoxHandler>().clearHUD();
    }

    public void leave_antipsychotics(){
        FindObjectOfType<DialogueBoxHandler>().clearHUD();
    }
}

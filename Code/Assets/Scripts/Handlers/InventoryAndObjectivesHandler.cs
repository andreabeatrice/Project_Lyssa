using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//This class is attached to the UI game object inventory_and_objectives & and is used to close the popup after the user has opened it by clicking on Fern (set up in Scripts/Handlers/PlayerClickHandler.cs)
public class InventoryAndObjectivesHandler : MonoBehaviour
{
    public GameObject inventoryAndObjectives;
   
    public Button btn;

    public Animator animatorForIO;

    void Update()
    {

        

    }

    //this is the OnClick() action of the io_close button
    public void closeIandO()
    {
        StartCoroutine(PopupClose());
    }

    IEnumerator PopupClose()
    {
        animatorForIO.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.4f);
        inventoryAndObjectives.SetActive(false);
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiaryClick : MonoBehaviour

{
    public AudioSources allAudio;
    public AudioSource clickSound;
    public AudioSource pageTurn;
    public AudioSource bookClose;
    public GameObject _HUD;

    public GameObject diary_sprite;

    public TMP_Text dialogHeading;

    public TMP_Text dialogBody;

    public GameObject diary_dialog;
   
    public Animator animator_diary;

    public GameObject next_page_button;

    public GameObject prev_page_button;

    public GameObject hide_diary_button;

    public GameObject pillow, keycard;

    //this is the OnClick() action of the io_close button
    public void closeDiary()
    {
        StartCoroutine(PopupClose());
    }

    IEnumerator PopupClose()
    {
        animator_diary.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.4f);
        diary_dialog.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){

        diary_dialog.SetActive(true);
        clickSound.Play();
       //allAudio.playClickSound();

        animator_diary.SetBool("isOpen", true);

        _HUD.SetActive(false);

        prev_page_button.SetActive(false);
        hide_diary_button.SetActive(false);

        dialogBody.text = "i feel sick. the lights are too bright and the machines are too loud and " + 
                            "i think <color=#bd102d>otto passed me a note yesterday</color> but i can’t remember what it said because they changed " + 
                            "my meds again even though they said i was doing better. better? what’s better? i’m never gonna " + 
                            "get better. i’m never gonna leave.";


        
    }

    public void nextpage(){
       // pageTurn.Play();
        allAudio.playPageTurn();
        next_page_button.SetActive(false);
        prev_page_button.SetActive(true);
        hide_diary_button.SetActive(true);

        dialogBody.text =  "the new meds tell me things. they said that the "+ 
                         "new nurse is evil and that i’m the only one who can get proof. so i stole it i stole <color=#bd102d>her key card</color> " + 
                         "and i hid it and now i’ll know who she is. they won’t let me go, not the meds or the "+
                         "voices or the doctors. i’m going to die here—";
    }

    public void previouspage(){
        //pageTurn.Play();
        allAudio.playPageTurn();
        prev_page_button.SetActive(false);
        next_page_button.SetActive(true);
        hide_diary_button.SetActive(false);

        dialogBody.text = "i feel sick. the lights are too bright and the machines are too loud and " + 
                            "i think <color=#bd102d>otto passed me a note yesterday</color> but i can’t remember what it said because they changed " + 
                            "my meds again even though they said i was doing better. better? what’s better? i’m never gonna " + 
                            "get better. i’m never gonna leave.";
    }

    public void HideDiary(){
        //bookClose.Play();
        allAudio.playBookClose();
        animator_diary.SetBool("isOpen", false);
        diary_sprite.GetComponent<Renderer>().enabled = false;
        DestroyImmediate(diary_sprite.GetComponent<PolygonCollider2D>());;
        StartCoroutine(PopupClose());

        HelperMethods.InventoryEnqueue("HER diary");
        HelperMethods.ObjectivesDequeue("Go clean the patients' rooms");
        HelperMethods.ObjectivesEnqueue("Find the note from Otto");
        HelperMethods.ObjectivesEnqueue("Find the nurse's key card");

        keycard.GetComponentsInChildren<DialogueClick>()[0].canClick = true;

       pillow.GetComponentsInChildren<objectDrag_nodialog>()[0].canDrag =true;
    }

    

}

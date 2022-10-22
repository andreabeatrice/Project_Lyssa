using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScript : MonoBehaviour
{

    public GameObject fern;
    public Animator FernAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //TESTING 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrinkMilk(){
        fern.SetActive(true);
        FernAnimator.Play("Player_Drinking_Milk");
        FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();

        Globals.deaths.Add("'No outside food' isn't just a suggestion.");

        StartCoroutine(Dies());

    }

    public IEnumerator Dies(){
        yield return new WaitForSeconds(5f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");
    }



    public IEnumerator Exp(){
        yield return new WaitForSeconds(5f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("ExperimentationDeath_CutScene_Kitchen", "crossfade_start");
    }

}

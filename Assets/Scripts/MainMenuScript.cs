using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainMenuScript : MonoBehaviour
{
    
    public Animator gate_animator, asylum_animator;

    public bool opened;

    public GameObject start, load, settings, gate, quit;

    public static string path;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/player.save";

         if(!File.Exists(path)){
            load.GetComponent<Button>().interactable = false;
         }
        opened = false;
        //GameObject.Find("Setting_Button").GetComponent<Button>().interactable = false;
    }



    public void StartGame()
    {
        if(File.Exists(path)){
            //popup

            File.Delete(path);
        }

        HelperMethods.ResetGlobals();

        gate_animator.Play("gate_opening_anim");
        
        opened = true;

        StartCoroutine(gatesopen());

        GameObject.Find("Start").SetActive(false);
        GameObject.Find("LoadSave").SetActive(false);
        GameObject.Find("Settings").SetActive(false);
        GameObject.Find("Quit").SetActive(false);

        //Reset globals in case player wants to retry
    }

    public void LoadGame()
    {
        //PlayerController p = FindObjectOfType<PlayerController>();
        SaveData data = SaveSystem.LoadPlayer();
        data.AssignData();

        //Debug.Log(Globals.objectives.Peek());

        gate_animator.Play("gate_opening_anim");

        StartCoroutine(gatesopen());
        opened = true;

        //StartCoroutine(gatesopen());
        start.SetActive(false);
        load.SetActive(false);
        settings.SetActive(false);

        SceneManager.LoadScene(Globals.currentScene);

    }

    IEnumerator gatesopen()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2f);

        gate.SetActive(false);

        asylum_animator.Play("zoom_animation");

        StartCoroutine(changescene());

        //After we have waited 5 seconds print the time again.
        
    }

    IEnumerator changescene()
    {
        yield return new WaitForSeconds(2f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("TriggerWarning", "crossfade_start");
    }

    public void OpenSettings(){
        SceneManager.LoadScene("mainMenu_Settings");
    }


}

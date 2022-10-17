using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;

    public GameObject PauseButton;

    public GameObject settingsPanel;

    public static string path;

    void Start()
    {
        path = Application.persistentDataPath + "/player.save";
        //PauseMenuUI.SetActive(false);
        //PauseButton.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                if (Globals.paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        PauseButton.SetActive(true);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        Globals.paused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        
        settingsPanel.SetActive(false);
        Time.timeScale = 0f;
        Globals.paused = true;
        PauseButton.SetActive(false);
    }

    public void PauseForPopup(){
        Time.timeScale = 0f;
        Globals.paused = true;
        PauseButton.SetActive(false);
    }

    public void SavePlayer(){
        this.Resume();
        SaveSystem.SavePlayer();
    }

    public void SaveAndQuit(){
        this.Resume();
        SaveSystem.SavePlayer();
        FindObjectOfType<LevelLoader>().LoadNextLevel("MainMenu", "crossfade_start");
    }

    public void openSettings(){
        settingsPanel.SetActive(true);
    }

    public void closeSettings(){
        settingsPanel.SetActive(false);
    }

    public void restart(){
        if(File.Exists(path)){
            //popup

            File.Delete(path);
        }

        SceneManager.LoadScene("MainMenu");


    }


    public void Quit()
    {
        Application.Quit();
    }
}

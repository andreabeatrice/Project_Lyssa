using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;

    public GameObject PauseButton;

    public GameObject settingsPanel;
    void Start()
    {
        PauseMenuUI.SetActive(false);
        PauseButton.SetActive(true);
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
        PauseButton.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 0f;
        Globals.paused = true;
    }

    public void SavePlayer(){
        this.Resume();
        SaveSystem.SavePlayer();
    }

    public void SaveAndQuit(){
        this.Resume();

        SaveSystem.SavePlayer();
        SceneManager.LoadScene("MainMenu");
    }

    public void openSettings(){
        settingsPanel.SetActive(true);
    }

    public void closeSettings(){
        settingsPanel.SetActive(false);
    }


    public void Quit()
    {
        Application.Quit();
    }
}

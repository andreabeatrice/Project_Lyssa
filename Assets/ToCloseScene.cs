using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCloseScene : MonoBehaviour
{

    public string deathSentence;

    public AudioSources AllAudio;

    public Animator nsp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  ToDeathScene(){
        Globals.deaths.Add(deathSentence);

        FindObjectOfType<LevelLoader>().LoadNextLevelLong("DeathScreen", "crossfade_start", 1f);
    }

    public void PlayNewspaperSound(){
        AllAudio.playNewspaperSpin();
    }

    public void PlayMovingManholeCover(){
        AllAudio.playMetalDrag();
    }

    public void NewspaperAnimation(){
        nsp.Play("win_newspaper");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        Globals.paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel(string scenename, string animname)
    {
        
        StartCoroutine(LevelTransition(scenename, animname, 1.5f));
    }

        public void LoadNextLevelLong(string scenename, string animname, float time)
    {
        
        StartCoroutine(LevelTransitionLong(scenename, animname, time));
    }


    IEnumerator LevelTransition(string scenename, string animname, float time)
    {
        transition.Play(animname);

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(scenename);

    }

    IEnumerator LevelTransitionLong(string scenename, string animname, float time)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.


        //After we have waited 5 seconds print the time again.


        yield return new WaitForSeconds(time);

        transition.Play(animname);

        SceneManager.LoadScene(scenename);

        //

    }


}

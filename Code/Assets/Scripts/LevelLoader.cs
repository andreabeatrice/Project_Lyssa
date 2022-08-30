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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel(string scenename, string animname)
    {
        
        StartCoroutine(LevelTransition(scenename, animname));
    }

    IEnumerator LevelTransition(string scenename, string animname)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.


        //After we have waited 5 seconds print the time again.
        transition.Play(animname);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(scenename);

        //

    }
}
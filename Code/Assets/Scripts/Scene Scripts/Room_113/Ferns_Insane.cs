using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferns_Insane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.deaths.Add("Looks like you didn't really care enough about your mental health. It's important, you know. Maybe try meditation.");

        StartCoroutine(PostDeathScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PostDeathScene() //each sentence
    {
        yield return new WaitForSeconds(4f);

        //change scene
        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");
    }
}

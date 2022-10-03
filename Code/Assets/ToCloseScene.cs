using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCloseScene : MonoBehaviour
{

    public string deathSentence;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToDeathScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ToDeathScene(){
        yield return new WaitForSeconds(7f);

        Globals.deaths.Add(deathSentence);

        SceneManager.LoadScene("DeathScreen");
    }
}

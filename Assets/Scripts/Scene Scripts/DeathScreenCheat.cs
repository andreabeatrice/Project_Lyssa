using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenCheat : MonoBehaviour
{

    private string konamiCode = ""; //Up-Up-Down-Down-Left-Right-Left-Right-B-A 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                konamiCode += "Up-";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)){
                konamiCode += "Down-";
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                konamiCode += "Left-";
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                konamiCode += "Right-";
            }
            if (Input.GetKeyDown(KeyCode.B)){
                konamiCode += "B-";
            }
            if (Input.GetKeyDown(KeyCode.A)){
                konamiCode += "A";
            }

        if (konamiCode.Contains("Up-Up-Down-Down-Left-Right-Left-Right-B-A")){
            Globals.deaths.Add("You sure think you're clever. When were you born, 1992?");
            StartCoroutine(PostDeathScene());
        }

    }

    public IEnumerator PostDeathScene() //each sentence
    {
        yield return new WaitForSeconds(3f);

        //change scene
        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PianoCheck : MonoBehaviour
{
    public PlaySomeonesAnim pla;
    public TextMeshProUGUI keys; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keys.text.Length == 4 && !keys.text.Contains("FEFD")){
            keys.text = "";
        }
        else if (keys.text.Length == 4 && keys.text.Contains("FEFD")){
            keys.text = "";
            pla.play();

            FindObjectOfType<DialogueBoxHandler>().showHUD();

            Sentence[] convincingDialogue = new Sentence[]{ new Sentence("A secret passage??", null, "Fern", ColorCodes.fern)};

            FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, "", null, true);

            StartCoroutine(SecretPassage());
        }
        
    }

    public IEnumerator SecretPassage(){
        yield return new WaitForSeconds(3f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("Basement_4_LeavesBoiler", "crossfade_start");
    }
}

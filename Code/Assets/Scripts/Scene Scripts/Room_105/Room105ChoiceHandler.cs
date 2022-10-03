using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room105ChoiceHandler : MonoBehaviour
{

    public Animator otto;

    public AudioSources AllAudio;

    public GameObject[] flames = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanicOtto(){
        Sentence[] convincingDialogue = new Sentence[]{ new Sentence("No No No No No No No No No No If I talk about it they'll take me next that's why they took—", null, "Fern", ColorCodes.patients)};

        Globals.deaths.Add("(1) Cigarettes are against the rules. (2) They're very bad for you. (3) Don't ask people questions that make them uncomfortable.");

        FindObjectOfType<DialogueManager>().StartDialogue(convincingDialogue, "", null, true);

        otto.Play("otto_smoking_panic");

        StartCoroutine(CatchFire(0));

        StartCoroutine(Dies());

        
    }

    public IEnumerator CatchFire(int i){
        
        
        if (i < 10){
            flames[i].SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);

        i += 1;

        StartCoroutine(CatchFire(i));
        
    }

    public IEnumerator Dies(){
        yield return new WaitForSeconds(5f);

        FindObjectOfType<LevelLoader>().LoadNextLevel("DeathScreen", "crossfade_start");
    }
}

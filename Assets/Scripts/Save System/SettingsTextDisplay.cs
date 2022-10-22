using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SettingsTextDisplay : MonoBehaviour
{

    public TMP_Text SpeechPlaceholder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Type(){
        StopAllCoroutines();
        StartCoroutine(TypeSentence("You know you're only wasting your own time, right?"));
    }

    
    public IEnumerator TypeSentence(string s) //each sentence
    {


        SpeechPlaceholder.text = "";

        foreach (char letter in s.ToCharArray()){
            SpeechPlaceholder.text += letter;
            yield return new WaitForSeconds(Globals.typingSpeed);
        }

            
    }
}

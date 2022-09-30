using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueAutoplayManager : MonoBehaviour { 

    //Queue is FIFO so sentences will be in order even if they play dialogue many times
    private Queue<Sentence> sentences = new Queue<Sentence>();

    public TMP_Text nameText;

    public TMP_Text dialogText;
   // public AudioSources allAudio;
    public GameObject skipButton;

    public AudioSource clickSound;

    public AudioSource talking;

    private string[] choices;

    private GameObject choice1;
    private GameObject choice2;
    private GameObject choice3;

    private bool speech;

    public bool inConversation = false;

    


    // Start is called before the first frame update
    void Start()
    {
        //sentences 
        Globals.currentScene = SceneManager.GetActiveScene().name;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused && inConversation == true ){
            
            if (sentences.Count == 0){
                
            }
            else {
                DisplayNextSentence();
            }
            //skip to next sentence
            
        }

    }

    public void playClickSound()
    {
        clickSound.Play();
    }

    public void setConversationStatus(bool s){
        inConversation = s;
    }

    public void StartDialogue(Sentence[] interactions, string[] c, GameObject[] choiceButtons, bool speech)
    {
        inConversation = true;

        this.choices = c;

        FindObjectOfType<PlayerController>().frozen = true;

        if (choiceButtons[0] != null)
        this.choice1 = choiceButtons[0];

        if (choiceButtons[1] != null)
            this.choice2 = choiceButtons[1];

        if (choiceButtons[2] != null)
            this.choice3 = choiceButtons[2];

        if (choice1 != null)
            choice1.SetActive(false);

        if (choice2 != null)
            choice2.SetActive(false);

        if (choice3 != null)
            choice3.SetActive(false);

        this.speech = speech;

        skipButton.SetActive(false);

        sentences.Clear();

        foreach (Sentence s in interactions)
        {
            sentences.Enqueue(s);
        }

        DisplayNextSentence();

    }


    public void DisplayNextSentence()
    {
        Sentence s = sentences.Dequeue();

        if(s.voice !=null)
        {
            talking = s.voice;
        }

        if(talking!=null && this.speech)
        {
            talking.Play();// plays for all direct dialogue
        }

        string sentence = s.words;

        
        dialogText.color = s.textcolor;

        if (nameText != null){
            nameText.text = s.name;
            nameText.color = s.textcolor;
        }
            

        dialogText.text = sentence;

        StopAllCoroutines();
        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        StartCoroutine(TypeSentence(sentence));

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else {
            StartCoroutine(DNS());
        }

    }

   


    public IEnumerator DNS()
    {
        Sentence s = sentences.Dequeue();

        string sentence = s.words;


        float ttw = Globals.typingSpeed*sentence.ToCharArray().Length +2;
        
        yield return new WaitForSeconds(ttw);

        if(s.voice !=null)
        {
            talking = s.voice;
        }

        if(talking!=null && this.speech)
        {
            talking.Play();// plays for all direct dialogue
        }

 
        dialogText.color = s.textcolor;

        if (nameText != null){
            nameText.text = s.name;
            nameText.color = s.textcolor;
        }
            

        dialogText.text = sentence;

        StopAllCoroutines();
        FindObjectOfType<DialogueBoxHandler>().clearChoiceButtons();

        StartCoroutine(TypeSentence(sentence));

        if (sentences.Count == 0)
        {
            EndDialogue();
        }
        else {
            StartCoroutine(DNS());
        }

    }

    public IEnumerator TypeSentence(string sentence) //each sentence
    {
        dialogText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(Globals.typingSpeed);
        }
        if(talking!=null)
        {
            talking.Stop();
            
        }
        
    }

    void EndDialogue()
    {
        //Debug.Log("End of conversation");
        //skipButton.SetActive(false);

        if (choices != null && choice1 != null)
        {
            for (int i = 1; i <= choices.Length; i++)
            {
                if (i == 1)
                {
                    choice1.SetActive(true);
                    choice1.GetComponentInChildren<TextMeshProUGUI>().text = choices[i - 1];
                }
                if (i == 2)
                {
                    choice2.SetActive(true);
                    choice2.GetComponentInChildren<TextMeshProUGUI>().text = choices[i - 1];
                }
                if (i == 3)
                {
                    choice3.SetActive(true);
                    choice3.GetComponentInChildren<TextMeshProUGUI>().text = choices[i - 1];
                }
            }
        }
        else {
            StartCoroutine(ClearHeadsUp());
        }

        
    }

    public IEnumerator ClearHeadsUp(){
        yield return new WaitForSeconds(4f);

        FindObjectOfType<DialogueBoxHandler>().clearHUD();
        FindObjectOfType<PlayerController>().frozen = false;

    }

}

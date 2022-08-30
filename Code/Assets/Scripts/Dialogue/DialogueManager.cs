using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour { 

    //Queue is FIFO so sentences will be in order even if they play dialogue many times
    private Queue<string> sentences = new Queue<string>();

    public TMP_Text nameText;

    public TMP_Text dialogText;

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

        Debug.Log(Globals.currentScene);
        Debug.Log(Globals.primaryMouseButton);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused && inConversation == true && skipButton.activeSelf){
            
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

    public void StartDialogue(Dialogue di, string[] c, GameObject[] choiceButtons, bool speech)
    {
        inConversation = true;

        this.choices = c;

        this.choice1 = choiceButtons[0];

        this.choice2 = choiceButtons[1];

        this.choice3 = choiceButtons[2];

        if (choice1 != null)
            choice1.SetActive(false);

        if (choice2 != null)
            choice2.SetActive(false);

        if (choice3 != null)
            choice3.SetActive(false);

        this.speech = speech;

        skipButton.SetActive(true);

        sentences.Clear();

        if (nameText != null) {
            nameText.color = di.textcolor;
            nameText.text = di.name;
        }

        dialogText.color = di.textcolor;



        foreach (string sentence in di.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void StartDialogue(Dialogue di, string choice, GameObject c1, bool speech)
    {
        inConversation = true;

        this.choices = new string[] { choice };

        this.choice1 = c1;

        if (choice1 != null)
            choice1.SetActive(false);

        skipButton.SetActive(true);

        sentences.Clear();

        this.speech = speech;

        if (nameText != null)
        {
            nameText.color = di.textcolor;
            nameText.text = di.name;
        }

        dialogText.color = di.textcolor;

        foreach (string sentence in di.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    //Add to a skip button
    public void DisplayNextSentence()
    {

        if(talking!=null && this.speech)
        {
            talking.Play();// plays for all direct dialogue
        }

        string sentence = sentences.Dequeue();

        dialogText.text = sentence;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));

        if (sentences.Count == 0)
        {
            EndDialogue();

            Debug.Log(skipButton.activeSelf);
            return;
        }

    }

    private IEnumerator TypeSentence(string sentence) //each sentence
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
        skipButton.SetActive(false);

        if (choices != null)
        {
            for (int i = 1; i <= choices.Length; i++)
            {
                if (i == 1)
                {
                    clickSound.Play();
                    choice1.SetActive(true);
                    choice1.GetComponentInChildren<TextMeshProUGUI>().text = choices[i - 1];
                }
                if (i == 2)
                {
                   clickSound.Play();
                    choice2.SetActive(true);
                    choice2.GetComponentInChildren<TextMeshProUGUI>().text = choices[i - 1];
                }
                if (i == 3)
                {
                    clickSound.Play();
                    choice3.SetActive(true);
                    choice3.GetComponentInChildren<TextMeshProUGUI>().text = choices[i - 1];
                }
            }
        }

        
    }

    //Add to a skip button
    public void DisplayNextSentenceNoAnimation()
    {
                if(talking!=null && this.speech)
                {
                    talking.Play();// plays for all direct dialogue
                }
                
                string sentence = sentences.Dequeue();

                dialogText.text = sentence;

                if (sentences.Count == 0)
                {
                    EndDialogue();
                    return;
                }

    }

    //StartDialogueNoAnimation(Dialogue di, string[] c, GameObject[] choiceButtons, bool speech)
    public void StartDialogueNoAnimation(Dialogue di, string[] c, GameObject[] choiceButtons, bool speech)
    {
            inConversation = true;

        this.choices = c;

        this.choice1 = choiceButtons[0];

        this.choice2 = choiceButtons[1];

        this.choice3 = choiceButtons[2];

        if (choice1 != null)
            choice1.SetActive(false);

        if (choice2 != null)
            choice2.SetActive(false);

        if (choice3 != null)
            choice3.SetActive(false);

        this.speech = speech;

        skipButton.SetActive(true);

        sentences.Clear();

        if (nameText != null) {
            nameText.color = di.textcolor;
            nameText.text = di.name;
        }

        dialogText.color = di.textcolor;



        foreach (string sentence in di.sentences)
        {
            sentences.Enqueue(sentence);
        }

            DisplayNextSentenceNoAnimation();

    }
}

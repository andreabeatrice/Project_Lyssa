using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueAutoplayManager : MonoBehaviour { 

    //Queue is FIFO so sentences will be in order even if they play dialogue many times
    private Queue<Sentence> Sentences = new Queue<Sentence>();

    public TMP_Text NamePlaceholder;

    public TMP_Text SpeechPlaceholder;
   // public AudioSources allAudio;
    public GameObject ContinueButton;

    public AudioSource clickSound;

    public AudioSource SpeakerVoice;

    private string[] ResponseStrings;

    private GameObject[] ResponseButtons;

    private GameObject choice1;
    private GameObject choice2;
    private GameObject choice3;

    private float TimeToClear;

    //If a specific animation needs to play after a sentence
    private Animator AnimationObject;
    private string SentenceAnimation;


    // Start is called before the first frame update
    void Start()
    {
        Globals.currentScene = SceneManager.GetActiveScene().name;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused && ContinueButton.activeSelf){
            
            if (Sentences.Count == 0){
                EndDialogue();
            }
            else {
                DisplayNextSentenceNoAnimation();
            }            
        }

    }

    //StartDialogue(Sentence[] i): takes in an array of sentences, one response, and the button that response will be assigned to 
        public void StartDialogue(Sentence[] i){
            //0) Clear any assigned animations
                AnimationObject = null;
                SentenceAnimation = "";
            
            //1) assign the passed-in sentences to the Sentences queue
                Sentences.Clear();
            
                foreach(Sentence s in i){
                    Sentences.Enqueue(s);
                }

            //TimeToClear
                TimeToClear = (i[i.Length-1].Words.ToCharArray().Length * Globals.typingSpeed) + 3;

            //4) show the continue button
                ContinueButton.SetActive(true);

            //5) Hide all previous Response buttons
                FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();



            //6) Start the first sentence
            StartCoroutine(DNS());

        }

    //StartDialogue(Sentence[] i, string c, GameObject b): takes in an array of sentences, one response, and the button that response will be assigned to 
        public void StartDialogue(Sentence[] i, string c, GameObject b){
            if(c == null){
                StartDialogue(i);
            }
            else {
                //0) Clear any assigned animations
                    AnimationObject = null;
                    SentenceAnimation = "";
                
                //1) assign the passed-in sentences to the Sentences queue
                Sentences.Clear();
            
                foreach(Sentence s in i){
                    Sentences.Enqueue(s);
                }

                //2) save the response string
                ResponseStrings = new string[]{c};

                //3) save the button that the response will be assigned to
                ResponseButtons = new GameObject[]{b};

                //4) show the continue button
                ContinueButton.SetActive(true);

                //5) Hide all previous Response buttons
                    FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();

                //6) Start the first sentence
                    StartCoroutine(DNS());
            }


        }

    //StartDialogue(Sentence[] i, string[] c, GameObject[] b): takes in an array of sentences, the possible responses, and the buttons that responses will be assigned to 
        public void StartDialogue(Sentence[] i, string[] c, GameObject[] b){

            if(c == null){
                StartDialogue(i);
            }
            else {
                //0) Clear any assigned animations
                    AnimationObject = null;
                    SentenceAnimation = "";

                //1) assign the passed-in sentences to the Sentences queue
                    Sentences.Clear();
                
                    foreach(Sentence s in i){
                        Sentences.Enqueue(s);
                    }

                //2) save the response string
                    ResponseStrings = new string[c.Length];

                    for(int j = 0; j < c.Length; j++){
                        ResponseStrings[j] = c[j];
                    }

                //3) save the button that the response will be assigned to
                    ResponseButtons = new GameObject[b.Length];

                    for(int j = 0; j < b.Length; j++){
                        ResponseButtons[j] = b[j];
                    }

                //4) show the continue button
                    ContinueButton.SetActive(true);

                //5) Hide all previous Response buttons
                        FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();

                //6) Start the first sentence
                    StartCoroutine(DNS());
            }

           

        }
    
    //DisplayNextSentence(): the key routine in DialogueManager, starts the next string in the Sentence array
        public void DisplayNextSentence()
        {

            //0) If a Sentence already played, and it had an Animator attached, play the animation
                if(AnimationObject != null)
                    AnimationObject.Play(SentenceAnimation);

            //1) Get the Sentence object we're going to be working with
                Sentence CurrentSentence = Sentences.Dequeue();

            //2) If the Sentence object has a voice attached, assign the voice
            if(CurrentSentence.Voice !=null)
                SpeakerVoice = CurrentSentence.Voice;

            //3) If the Sentence object has an Animator attached, assign the animation and animation name string
                AnimationObject = CurrentSentence.AnimationObject;
                SentenceAnimation = CurrentSentence.Play;

            //3) If the Sentence object has a TextColor assigned to it, assign that text colour to the placeholders
                NamePlaceholder.color = CurrentSentence.TextColor;
                SpeechPlaceholder.color = CurrentSentence.TextColor;

            //4) Get the string from the Sentence object
                string NextLine = CurrentSentence.Words;

            //5) Hide all previous Response buttons
                FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();

            //6) If a previous sentence was typing, stop it
                StopAllCoroutines();

            //7) Start the new sentence
                StartCoroutine(TypeSentence(NextLine));

            //8) If this method was called but there's nothing left in the Sentences queue, end the dialogue
                if (Sentences.Count == 0){
                    EndDialogue();
                    return;
                }

        }
        
    //TypeSentence(string s): Runs the text animation and voice audio
        public IEnumerator TypeSentence(string s) //each sentence
        {

            if(SpeakerVoice != null){
                SpeakerVoice.time = Random.Range(0.01f, SpeakerVoice.clip.length);
                SpeakerVoice.Play();
            }

            SpeechPlaceholder.text = "";

            foreach (char letter in s.ToCharArray()){
                SpeechPlaceholder.text += letter;
                yield return new WaitForSeconds(Globals.typingSpeed);
            }

            if(SpeakerVoice != null){
                SpeakerVoice.Stop();
            }
            
        }

    //EndDialogue(): Shows any assigned responses
        void EndDialogue(){

            if (ResponseStrings != null)
            {
                for (int j = 0; j < ResponseStrings.length-1; j++){
                    ResponseButtons[j].SetActive(true);
                    ResponseButtons[j].GetComponentInChildren<TextMeshProUGUI>().text = ResponseStrings[j];
                }
            }
            else {
                StartCoroutine(ClearHeadsUp());
            }
            
        }

    //DisplayNextSentenceNoAnimation(): shows the next line without playing the text animation
        public void DisplayNextSentenceNoAnimation(){
            //0) If a Sentence already played, and it had an Animator attached, play the animation
                    if(AnimationObject != null)
                        AnimationObject.Play(SentenceAnimation);

                //1) Get the Sentence object we're going to be working with
                    Sentence CurrentSentence = Sentences.Dequeue();

                //2) If the Sentence object has a voice attached, assign the voice
                if(CurrentSentence.Voice !=null)
                    SpeakerVoice = CurrentSentence.Voice;

                //3) If the Sentence object has an Animator attached, assign the animation and animation name string
                    AnimationObject = CurrentSentence.AnimationObject;
                    SentenceAnimation = CurrentSentence.Play;

                //3) If the Sentence object has a TextColor assigned to it, assign that text colour to the placeholders
                    NamePlaceholder.color = CurrentSentence.TextColor;
                    SpeechPlaceholder.color = CurrentSentence.TextColor;

                //4) Get the string from the Sentence object
                    string NextLine = CurrentSentence.Words;

                //5) Hide all previous Response buttons
                    FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();

                //6) Show this sentence
                SpeechPlaceholder.text = NextLine;

                //8) If this method was called but there's nothing left in the Sentences queue, end the dialogue
                    if (Sentences.Count == 0){
                        EndDialogue();
                        return;
                    }
        }


    public IEnumerator DNS() {
        //0) If a Sentence already played, and it had an Animator attached, play the animation
            if(AnimationObject != null)
                AnimationObject.Play(SentenceAnimation);

        //1) Get the Sentence object we're going to be working with
            Sentence CurrentSentence = Sentences.Dequeue();

        float TimeToWait = (Globals.typingSpeed * CurrentSentence.Words.ToCharArray().Length) + 2;
        
        yield return new WaitForSeconds(ttw);

        //2) If the Sentence object has a voice attached, assign the voice
            if(CurrentSentence.Voice !=null)
                SpeakerVoice = CurrentSentence.Voice;

        //3) If the Sentence object has an Animator attached, assign the animation and animation name string
            AnimationObject = CurrentSentence.AnimationObject;
            SentenceAnimation = CurrentSentence.Play;

        //4) If the Sentence object has a TextColor assigned to it, assign that text colour to the placeholders
            NamePlaceholder.color = CurrentSentence.TextColor;
            SpeechPlaceholder.color = CurrentSentence.TextColor;

        //4) Get the string from the Sentence object
            string NextLine = CurrentSentence.Words;

        //5) Hide all previous Response buttons
            FindObjectOfType<DialogueBoxHandler>().ClearChoiceButtons();

        //6) If a previous sentence was typing, stop it
            StopAllCoroutines();

        //7) Start the new sentence
            StartCoroutine(TypeSentence(NextLine));

        //8) If this method was called but there's nothing left in the Sentences queue, end the dialogue
        
        if (sentences.Count == 0)
        {
            EndDialogue();
        }
        else {
            StartCoroutine(DNS());
        }




    }

   
    //ClearHeadsUp(): clears the Dialogue Box from the screen if there were no given responses
        public IEnumerator ClearHeadsUp(){
            yield return new WaitForSeconds(TimeToClear);

            FindObjectOfType<DialogueBoxHandler>().ClearDialogueBox();
        }


}

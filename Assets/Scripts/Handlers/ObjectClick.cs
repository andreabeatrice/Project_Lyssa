using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class can be attached to any object that has a 2D collider and should perform an animation when clicked on
//This is different from the Choice Handler because it doesn't rely on buttons with OnClick() methods: 
//if players click on the object, the event will take place, they can't decide to do something else
//Important for the tutorial specifically
public class ObjectClick : MonoBehaviour
{
    public AudioSource openDoorSound;

    public Animator animator;

    public string clickAnimation;

    public string nextMethod;

    public GameObject HeadsUpDisplay;

    public GameObject noaction;

    //Proximity Abilities enabled
    public bool enableProximityReactions;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;
    //private bool popped = false;

    void Update(){
        if (enableProximityReactions== true && PlayerCollider.IsTouching(ObjectAreaCollider))
        {

            if(Input.GetKeyDown(KeyCode.Space) && !Globals.paused ){
                handle();
            }
            

        }
    }


    //OnMouseDown(): if the Collider attached to the object the script is attached to is clicked
        private void OnMouseOver()
        {
            
            if (Input.GetMouseButtonDown(Globals.primaryMouseButton) && !Globals.paused )
            {
                handle();

            }
        }

    //JanitorsDoorClick(): This Coroutine waits 1.5 seconds for the janitor's door animation to complete, then calls the LoadNextLevel() method of LevelLoader.cs
        //LoadNextLevel() creates a new scene, but uses a fade-to-black so that the transition is smoother
        public IEnumerator JanitorsDoorClick()
        {
            //yield on a new YieldInstruction that waits for 1.5 seconds.
            yield return new WaitForSeconds(1.5f);

            FindObjectOfType<LevelLoader>().LoadNextLevel("Janitors_Closet", "crossfade_start");

            

        }

    public void handle(){
        if (animator != null){
                    animator.Play(clickAnimation);
                }

                switch (nextMethod)
                {
                    case "JanitorsDoorClick":
                        if (!Globals.StorageRoom)
                        {
                            openDoorSound.Play();
                            StartCoroutine(JanitorsDoorClick());
                        }
                        else
                        {
                            HeadsUpDisplay.SetActive(true);

                            string[] sentences = new string[] { "I don't need to do that again right now." };

                            Color32 c = new Color32(135, 206, 253, 255);

                            Dialogue dialog = new Dialogue(sentences, "Fern", c);

                            FindObjectOfType<DialogueManager>().StartDialogue(dialog, "Okay", noaction, false);
                        }
                        
                        break;
            
                }
    }

}

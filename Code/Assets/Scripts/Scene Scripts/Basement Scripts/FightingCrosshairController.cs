using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCrosshairController : MonoBehaviour
{
    public int hit = 0;
    
    public AudioSources AllAudio;


    public Collider2D KrausBody;

    public Rigidbody2D crosshair;

    public GameObject crosshair_object;

    public Sprite none, crosshair_sprote;

    public Animator fern, kraus;

    private bool called = false;

    private float timeToFight;
    // Start is called before the first frame update
    void Start()
    {
        spawn();

        if (Globals.insanity > 3){
            timeToFight = 60 / (Globals.insanity/3);
        }
        else {
            timeToFight = 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!called && crosshair_object.activeSelf){
            StartCoroutine(gonnaSpawn());
            called = true;

            

            Debug.Log(timeToFight);
        }
        if (crosshair_object.activeSelf && timeToFight > 0){
            timeToFight -= Time.deltaTime;
        }
        else if (timeToFight <= 0){
            Debug.Log("He wins.RIP");
            kraus.Play("kraus_kick");
            fern.Play("player_knockout");
            crosshair_object.SetActive(false);

            Globals.deaths.Add("Did you read the instructions? They ~said~ that you had a limited time.");

            FindObjectOfType<LevelLoader>().LoadNextLevelLong("DeathScreen", "crossfade_start", 3f);
        }

        
        //-= Time.deltaTime;
    }

    public void spawn(){
        //KrausBody
        //Get an x value between KrausBody.bounds.Center.x + KrausBody.bounds.Extent.x and KrausBody.bounds.Center.x - KrausBody.bounds.Extent.x
        //Get an y value between KrausBody.bounds.Center.y + KrausBody.bounds.Extent.y and KrausBody.bounds.Center.y - KrausBody.bounds.Extent.y
        //Set the rigid body position to that value
        crosshair_object.GetComponent<SpriteRenderer>().sprite = crosshair_sprote;

        float x = Random.Range((KrausBody.bounds.center.x - KrausBody.bounds.extents.x), (KrausBody.bounds.center.x + KrausBody.bounds.extents.x));
        float y = Random.Range((KrausBody.bounds.center.y - KrausBody.bounds.extents.y), (KrausBody.bounds.center.y + KrausBody.bounds.extents.y));
    


        crosshair.position = new Vector2(x, y);
    }

    public IEnumerator gonnaSpawn(){
        float timetowaitMax, timetowaitMin;

        if(Globals.insanity != 0){
            timetowaitMin = 0f;
            timetowaitMax = 5 - (Globals.insanity/4);
        }
        else {
            timetowaitMin = 2f;
            timetowaitMax = 5f;
        }
        
        yield return new WaitForSeconds(Random.Range(timetowaitMin, timetowaitMax));


        spawn();
        called = false;
    }

    private void OnMouseDown()
    {

        if (hit < 3 && timeToFight > 0){
             StartCoroutine(gonnaSpawn());
            crosshair_object.GetComponent<SpriteRenderer>().sprite = none;

            int move = Random.Range(1,4);

            switch (move){
                case 1:
                    AllAudio.playPunch();
                    fern.Play("Player_Jab_Cross");
                break;
                case 2:
                    AllAudio.playPunch();
                    fern.Play("Player_Jab");
                break;
                case 3:
                    AllAudio.playKick();
                    fern.Play("Player_Kick");
                break;
            }

            hit++;

            FindObjectOfType<KrausCollider>().hit = 0;
        } 

        else {
            //Change scne
            AllAudio.playKick();
            fern.Play("Player_Kick");
            kraus.Play("kraus_knockedout");

            Debug.Log("You win!");
            crosshair_object.SetActive(false);
            KrausBody.enabled = false;
            Globals.playerPositionOnMap = new Vector2(-1.31f, 72.31f);
            FindObjectOfType<LevelLoader>().LoadNextLevelLong("Basement_3_Win", "crossfade_start", 4f);
        }
       
        
    }

    public void FIGHT(){
        crosshair_object.SetActive(true);
        KrausBody.enabled = true;
    }

}

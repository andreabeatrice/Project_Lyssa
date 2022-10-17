using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_8_Insanity17 : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D tarr;
    public Rigidbody2D rb;

    public GameObject nurseSprite;

    void Start()
    {
            Vector3 tarrPosition = Globals.playerPositionOnMap;
            tarrPosition.y = tarrPosition.y + 4;
            tarrPosition.x = tarrPosition.x - 2;

            Debug.Log(tarrPosition);
            tarr.position = tarrPosition;
            StartCoroutine(callNurse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator callNurse(){
        yield return new WaitForSeconds(2);
        StartCoroutine(InsaneFernRoom());
        nurseSprite.GetComponentsInChildren<BoxCollider2D>()[0].enabled = true;
    }

    public IEnumerator InsaneFernRoom(){
        yield return new WaitForSeconds(10);
        FindObjectOfType<LevelLoader>().LoadNextLevel("Room113_Fern", "crossfade_start");
    }


}

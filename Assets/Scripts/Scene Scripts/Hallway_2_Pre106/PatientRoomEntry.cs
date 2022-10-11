using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientRoomEntry : MonoBehaviour
{
    AudioSources allAudio;
    public Collider2D PlayerCollider;
    public Collider2D ObjectAreaCollider;

    // Start is called before the first frame update
    void Start()
    {
        allAudio = FindObjectOfType<AudioSources>();
    }

    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space) && PlayerCollider.IsTouching(ObjectAreaCollider))
            OnMouseDown();
    }

    void OnMouseDown()
    {
        allAudio.playOpenDoor();
        FindObjectOfType<LevelLoader>().LoadNextLevel(this.name, "crossfade_start");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetCollider : MonoBehaviour
{
    public Collider2D draw;

    public GameObject cabinet;

    public Sprite open_me, bothopen, noneopen, youopen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        if (cabinet.GetComponent<SpriteRenderer>().sprite.name == "FilingcabinetClosed"){
            cabinet.GetComponent<SpriteRenderer>().sprite = open_me;
        }
        else if(cabinet.GetComponent<SpriteRenderer>().sprite.name == "Filingcabinet_bothopen"){
            cabinet.GetComponent<SpriteRenderer>().sprite = youopen;
        }
        else if (cabinet.GetComponent<SpriteRenderer>().sprite = open_me){
            cabinet.GetComponent<SpriteRenderer>().sprite = noneopen;
        }
        else {
            cabinet.GetComponent<SpriteRenderer>().sprite = bothopen;
        }
        
    }

    
}

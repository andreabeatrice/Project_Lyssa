using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveableObject 
{
    public GameObject item;
    public string name;
    public Vector3 position;
    public bool state;

    public MoveableObject(GameObject i){
        this.item = i;
        this.name= item.name;
        this.position =item.transform.position;
        this.state = false;

    }

    public string ToString(){
        string s = "name: " + name + " | position: " + position + " | state: " + state + "\n";
        return s;
    }

    public void SetName(string n){
        this.name = n;
    }

    public void SetPosition(Vector3 pos){
        this.position = pos;
    }

    public void SetState(bool s){
        this.state = s;
    }

    public string GetName(){
        return name;
    }

    public Vector3 GetPosition(){
        return position;
    }

    public bool GetState(){
        return state;
    }
}

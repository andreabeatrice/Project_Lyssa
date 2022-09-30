using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence
{
        //The dialogue the clicked on object will play
        [TextArea(3, 10)]
        public string words;

        public AudioSource voice;

        //Not assigned for the narration
        public string name;

        //This is used to set the colour of the text, do differentiate between Fern's thoughts & the narration
        public Color32 textcolor = new Color32(255, 255, 255, 255);

        public void makeFern(){
            textcolor = new Color32(135, 206, 253, 255);
            name = "Fern";

            Debug.Log(GameObject.FindGameObjectWithTag("AudioPrefab").transform.GetComponentsInChildren<AudioSource>());
            GameObject.FindGameObjectWithTag("AudioPrefab").transform.GetComponentsInChildren<AudioSource>();
            
        }

        public void makeNurseTarr(){
            textcolor = new Color32(126,179,189, 255);
            name = "Nurse Tarr";
        }

        public Sentence(string w){
            words = w;

            voice = null;

            name = "";
        }

        public Sentence(string w, int f){
            words = w;

            makeFern();

        }

        public Sentence(string w, AudioSource v, string n){
            words = w;
            voice = v;
            name = n;
        }

        public Sentence(string w, AudioSource v, string n, Color32 c){
            words = w;
            voice = v;
            name = n;
            textcolor = c;
        }
}

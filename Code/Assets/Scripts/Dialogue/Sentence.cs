using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence
{
        //The dialogue the clicked on object will play
        [TextArea(3, 10)]
        public string Words;

        public AudioSource Voice;

        //Not assigned for the narration
        public string Name;

        //This is used to set the colour of the text, do differentiate between Fern's thoughts & the narration
        public Color32 TextColor = new Color32(255, 255, 255, 255);

        //If a specific animation needs to play after a sentence
        public Animator AnimationObject;
        public string Play;

        public void MakeFern(){
            TextColor = new Color32(135, 206, 253, 255);
            Name = "Fern";
        }

        public void MakeNurseTarr(){
            TextColor = new Color32(126,179,189, 255);
            Name = "Nurse Tarr";
        }

        public Sentence(string w){
            Words = w;

            Voice = null;

            Name = "";
        }

        public Sentence(string w, int f){
            Words = w;

            MakeFern();

        }

        public Sentence(string w, AudioSource v, string n){
            Words = w;
            Voice = v;
            Name = n;
        }

        public Sentence(string w, AudioSource v, string n, Color32 c){
            Words = w;
            Voice = v;
            Name = n;
            TextColor = c;
        }

        public Sentence(string w, AudioSource v, string n, Color32 c, Animator o, string p){
            Words = w;
            Voice = v;
            Name = n;
            TextColor = c;
            AnimationObject = o;
            Play = p;
        }
}

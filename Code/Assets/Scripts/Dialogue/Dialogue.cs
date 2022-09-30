using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source: How to make a Dialogue System in Unity
//        https://www.youtube.com/watch?v=_nRzoTzeyxU


//Object that can be passed into DialogueClick.cs whenever we want to start a new dialogue
//Makes that you can assign values in game editor

[System.Serializable]
public class Dialogue
{
        //The dialogue the clicked on object will play
        [TextArea(3, 10)]
        public Sentence[] sentences;

    
    // Dialogue(string[] sent, string n): Constructor that creates a Dialogue object so that DialogueManager can be called from a script.
    // Auto-assigns text colour to white
    //     public Dialogue(Sentence[] sentences)
    //     {

    //         int i = 0;

    //         sentences = new string[sent.Length];


    //         foreach (string s in sent)
    //         {
    //             sentences[i] = s;
    //             i++;
    //         }

    //         if(n != null && n.Contains("Fern")){
    //             this.makeFern();
    //         }
    //     }

    // Dialogue(string[] sent, string n, Color32 cl): Constructor overload that creates a Dialogue object so that DialogueManager can be called from a script 
    // && lets a programmer assign a text colour
    //     public Dialogue(string[] sent, string n, Color32 cl, AudioSource v)
    //     {
    //     if (v != null)
    //     {
    //         voice = v;
    //     }

    //         textcolor = cl;

    //         name = n;

    //         int i = 0;

    //         sentences = new string[sent.Length];

    //         foreach (string s in sent)
    //         {
    //             sentences[i] = s;
    //             i++;
    //         }

    //         if(n != null && n.Contains("Fern")){
    //             this.makeFern();
    //         }
    // }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveAddedScript : MonoBehaviour
{
    private int ObjectivesCount;

    public PlayAnimation NewObjectivePopup;

    Queue<string> TempObjectives = new Queue<string>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (string task in Globals.objectives){
            TempObjectives.Enqueue(task);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TempObjectives.Count == 0 || TempObjectives.Peek() != Globals.objectives.Peek() || Globals.objectives.Count > TempObjectives.Count){
            TempObjectives.Clear();

            foreach (string task in Globals.objectives){
                TempObjectives.Enqueue(task);
            }
            NewObjectivePopup.PlayObjectAnimation();
        }
        
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperMethods{
    //InventoryEnqueue(string item): Helper Method- Takes the name of an item to be added to the inventory & checks if the item is already in the inventory
        //if the item isn't already in the inventory, it adds it to the Globals.inventory queue
        public static void InventoryEnqueue(string item)
        {
            foreach (string existingItem in Globals.inventory)
            {
                if (existingItem == item)
                {
                    return;
                }
            }

            Globals.inventory.Enqueue(item);
        }

    //ObjectivesEnqueue(string task): Helper Method- Takes the name of a task to be added to the player's objectives & checks if it's already been added
        //if the task in the list is the "default" task, it replaces that task
        //if the task has already been added, it doesn't add it again
        //if the task has not been added, it adds it to the Globals.objectives queue
        public static void ObjectivesEnqueue(string task)
        {
            foreach (string existingTask in Globals.objectives)
            {
                if (existingTask == "You haven't been told to do anything yet. Maybe try talking to people?")
                {
                    Globals.objectives.Dequeue();
                    break;
                }
                if (existingTask == task)
                {
                    return;
                }
            }

            Globals.objectives.Enqueue(task);
        }

        public static void ObjectivesDequeue(string task)
        {
            Queue<string> temp = new Queue<string>();

            // Drain (empty) the queue, one element at a time
            while (Globals.objectives.Count > 0)
            {
                string xisting = Globals.objectives.Dequeue();
                if (xisting.Contains(task))
                {
                    //
                }
                else {
                    temp.Enqueue(xisting);
                }
            }

            foreach(string it in temp){
                Globals.objectives.Enqueue(it);
            }
        }

        public static void InventoryDequeue(string item)
        {
            Queue<string> temp = new Queue<string>();

            // Drain (empty) the queue, one element at a time
            while (Globals.inventory.Count > 0)
            {
                string xisting = Globals.inventory.Dequeue();
                if (xisting.Contains(item))
                {
                    //
                }
                else {
                    temp.Enqueue(xisting);
                }
            }

            foreach(string it in temp){
                Globals.inventory.Enqueue(it);
            }
        }

        public static bool CheckInventory(string lookFor){
            foreach(string item in Globals.inventory){
                if (item.Contains(lookFor)){
                    return true;
                }
            }
            return false;
            
        }

        public static void PrintObjectives(){
            foreach(string item in Globals.objectives){
                Debug.Log(item);
            }
        }

        public static void ResetGlobals(){
            Globals.insanity = 0;

            Globals.inventory = new Queue<string>();
            Globals.objectives = new Queue<string>();
            Globals.playerPositionOnMap = new Vector3(0, 3, 0);
            Globals.paused = false;

            Globals.canClick = false;

            Globals.currentScene = "";

            //Used to determine whether player has completed the Janitors_Closet scene in the tutorial
            Globals.StorageRoom = false;


            Globals.mopped = false;

            Globals.direction = "";

            Globals.playedTime = 0.0f;
        }
}

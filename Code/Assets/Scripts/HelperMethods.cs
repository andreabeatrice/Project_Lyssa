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

        public static void ObjectivesDequeue(string completedTask){
            Queue<string> tempO = new Queue<string>();

            if (Globals.objectives.Peek() == completedTask){
                    Globals.objectives.Dequeue();
            }
            else {
                foreach(string s in Globals.objectives){
                    if(Globals.objectives.Peek() != completedTask){
                        tempO.Enqueue(s);
                    }
                    else{ 
                        Debug.Log(s);
                    }
                }
            }

            // foreach(string s in tempO){
            //     Globals.objectives.Enqueue(s);

            // }
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
                    temp.Enqueue(Globals.inventory.Dequeue());
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
}
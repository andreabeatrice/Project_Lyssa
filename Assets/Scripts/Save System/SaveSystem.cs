using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

     public static string path = Application.persistentDataPath + "/player.save";


    public static void SavePlayer(){
        BinaryFormatter formatter = new BinaryFormatter();
       

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);

        stream.Close();
    }

        public static void SavePlayer(bool sett){
        BinaryFormatter formatter = new BinaryFormatter();
       

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(sett);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static SaveData LoadPlayer(){
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;

            stream.Close();

            return data;

        }
        else {
            Debug.LogError("Save file  not found in " + path);

            return null;
        }
    }

    
}

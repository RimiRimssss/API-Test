
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string saveFilePath;
    void Awake()
    {
        // Set the path to save the file
        saveFilePath = Application.persistentDataPath + "/saveData.dat";

    }

    // Function to save game data
    public void SaveGame(SaveData data)
    {
        FileStream file = File.Create(saveFilePath);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game saved to " + saveFilePath);
    }

    // Function to load game data
    public SaveData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            FileStream file = File.Open(saveFilePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            Debug.Log("Game loaded from " + saveFilePath);
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found!");
            return null;
        }
    }
}

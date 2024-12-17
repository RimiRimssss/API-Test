using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Game : MonoBehaviour
{
    public SaveManager saveManager;
    [SerializeField]
    public SaveData saveData;

    void Start()
    {
        // Initialize player data
/*        saveData = new SaveData
        {
            playerData = new PlayerData
            {
                playerScore = 100,
                playerPosition = new SerializableVector3(new Vector3(0, 1, 2)), // Convert to SerializableVector3
                playerName = "Player1"
            },
            inventoryData = new InventoryData
            {
                items = new InventoryItem[]
                {
                    new InventoryItem { itemName = "Potion", quantity = 5 },
                    new InventoryItem { itemName = "Sword", quantity = 1 }
                }
            },
            gameSettings = new GameSettings
            {
                soundVolume = 0.5f,
                musicVolume = 0.7f
            }
        };*/

        // Save the game data

        // Load the game data
/*        SaveData loadedData = saveManager.LoadGame();
        if (loadedData != null)
        {
            saveData = loadedData;
            Debug.Log("Loaded player name: " + loadedData.playerData.playerName);
            Debug.Log("Loaded player score: " + loadedData.playerData.playerScore);
            foreach (var item in loadedData.inventoryData.items)
            {
                Debug.Log("Loaded item: " + item.itemName + " Quantity: " + item.quantity);
            }
            Debug.Log("Loaded sound volume: " + loadedData.gameSettings.soundVolume);
        }*/
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Saved");
            saveManager.SaveGame(saveData);
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            SaveData loadedData = saveManager.LoadGame();
            if (loadedData != null)
            {
                saveData = loadedData;
                Debug.Log("Loaded player name: " + loadedData.playerData.playerName);
                Debug.Log("Loaded player score: " + loadedData.playerData.playerScore);
                foreach (var item in loadedData.inventoryData.items)
                {
                    Debug.Log("Loaded item: " + item.itemName + " Quantity: " + item.quantity);
                }
                Debug.Log("Loaded sound volume: " + loadedData.gameSettings.soundVolume);
            }
            else
            {
                Debug.Log("Data not found");
            }
        }
    }
}

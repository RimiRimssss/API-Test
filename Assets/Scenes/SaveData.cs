using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public PlayerData playerData;
    public InventoryData inventoryData;
    public GameSettings gameSettings;
}
[System.Serializable]

public class SerializableVector3
{
    public float x;
    public float y;
    public float z;

    // Constructor to convert from Unity's Vector3
    public SerializableVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    // Method to convert back to Unity's Vector3
    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

[System.Serializable]
public class PlayerData
{
    public int playerScore;
    public SerializableVector3 playerPosition;  
    public string playerName;
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;
}

[System.Serializable]
public class InventoryData
{
    public InventoryItem[] items;
}

[System.Serializable]
public class GameSettings
{
    public float soundVolume;
    public float musicVolume;
}

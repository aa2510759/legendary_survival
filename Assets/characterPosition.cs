using System;

using UnityEngine;

public class characterPosition : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    [ContextMenu("Save")]

    public void Save()
    {

        playerData.PlayerPos.X = transform.position.x;
        playerData.PlayerPos.Y = transform.position.y;


        CloudSaving.SaveData(playerData, "PlayerData");
        Debug.Log("Saved Data");
    }

    [ContextMenu("Load")]
    public async void Load()
    {
        var data = await CloudSaving.LoadData<PlayerData>("PlayerData");

        transform.position = new Vector2(data.PlayerPos.X, data.PlayerPos.Y);

        playerData.XP = data.XP;

        Debug.Log("loaded data");
    }
}




[Serializable]
public struct PlayerData
{
    public int XP;
    public PlayerPos PlayerPos;
}

[Serializable]
public struct PlayerPos
{
    public float X, Y;
}
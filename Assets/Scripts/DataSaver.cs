using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameData
{
    private static string fileToSave = "save.json";

    public List<int> StarsCount = new();

    public void Save()
    {
        string json = JsonUtility.ToJson(this);

        File.WriteAllText(
            Application.persistentDataPath + '/' + fileToSave,
            json
        );
    }

    public static GameData Load()
    {
        GameData data = new GameData();

        if (File.Exists(Application.persistentDataPath + '/' + fileToSave))
        {
            string json = File.ReadAllText(Application.persistentDataPath + '/' + fileToSave);

            GameData readedData = JsonUtility.FromJson<GameData>(json);

            data.StarsCount = new(readedData.StarsCount);
        }
        else
        {
            data.StarsCount = new List<int>(new int[] { 0 });
        }

        return data;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public static Saver Instance;
    string filePath;
    MapInfo info = new MapInfo();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }
    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json");
    }

   public void SaveInfo(MapInfo save)
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(save));
    }

    public MapInfo LoadInfo()
    {
        if (File.Exists(filePath))
        {
            info = JsonUtility.FromJson<MapInfo>(File.ReadAllText(filePath));
        }
        else
        {
            SaveInfo(info);
        }
        return info;
    }

}

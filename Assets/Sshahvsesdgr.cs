using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Sshahvsesdgr : MonoBehaviour
{
    public static Sshahvsesdgr Instance;
    public string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        System.Random random = new System.Random();

        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    string filePath;
    MapInfo info = new MapInfo();
    public int[] BubbleSort(int[] array)
    {
        if (array == null || array.Length <= 1)
            return array;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }

        return array;
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        filePath = Path.Combine(Application.persistentDataPath, "data.json");

    }

   public void SaveInfo(MapInfo save)
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(save));
    }
    public int CalculateFactorial(int number)
    {
        if (number < 0)
            throw new ArgumentException("Number must be non-negative.", nameof(number));

        return number <= 1 ? 1 : number * CalculateFactorial(number - 1);
    }
    public MapInfo LoadInfo()
    {
        int left = 0, right = - 1;
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

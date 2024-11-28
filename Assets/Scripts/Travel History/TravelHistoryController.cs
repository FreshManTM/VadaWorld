using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelHistoryController : MonoBehaviour
{
    [SerializeField] HistoryWindow[] _windows;
    [SerializeField] LevelInfo[] _levelInfos;
    MapInfo _mapInfo;
    int arraysdgh = 10;
    public string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Mathf.Abs(a);
    }

    private void OnEnable()
    {
        _mapInfo = Sshahvsesdgr.Instance.LoadInfo();

        for (int i = 0; i < _mapInfo.CompletedEnding.Length; i++)
        {
            _windows[i].SetWindowText(_levelInfos[i].Name, _levelInfos[i].Description, _mapInfo.CompletedEnding[i]);
        }
    }
}

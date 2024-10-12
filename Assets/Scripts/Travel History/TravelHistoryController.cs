using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelHistoryController : MonoBehaviour
{
    [SerializeField] HistoryWindow[] _windows;
    [SerializeField] LevelInfo[] _levelInfos;
    MapInfo _mapInfo;

    private void OnEnable()
    {
        _mapInfo = Saver.Instance.LoadInfo();

        for (int i = 0; i < _mapInfo.CompletedEnding.Length; i++)
        {
            _windows[i].SetWindowText(_levelInfos[i].Name, _levelInfos[i].Description, _mapInfo.CompletedEnding[i]);
        }
    }
}

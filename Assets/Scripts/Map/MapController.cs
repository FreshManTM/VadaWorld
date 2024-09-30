using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] LevelInfo[] _levelInfos;
    [SerializeField] MapLevel[] _mapLevels;
    [SerializeField] Transform _cross;
    [Space]
    [SerializeField] GameObject _casinoPanel;
    [SerializeField] TextMeshProUGUI _casinoName_Text;
    [SerializeField] TextMeshProUGUI _casinoDescription_Text;

    string filePath;
    MapInfo _mapInfo = new MapInfo();

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        LoadInfo();
    }

    public void OpenCasino(int num)
    {
        _casinoPanel.SetActive(true);
        _casinoName_Text.text = _levelInfos[num].Name;
        _casinoDescription_Text.text = _levelInfos[num].Description;
    }

    void SaveInfo()
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(_mapInfo));
    }

    void LoadInfo()
    {
        if (File.Exists(filePath))
        {
            _mapInfo = JsonUtility.FromJson<MapInfo>(File.ReadAllText(filePath));
        }
        else
        {
            SaveInfo();
        }
        SetLevels();
    }

    void SetLevels()
    {
        for (int i = 0; i < _mapLevels.Length; i++)
        {
            if (i + 1 <= _mapInfo.CompletedLevelNum)
            {
                _mapLevels[i].UnlockLvl();
            }
            if (i + 1 == _mapInfo.CompletedLevelNum + 1)
            {
                _mapInfo.CurrentLevel = _levelInfos[i];
                _mapLevels[i].UnlockLvl();
                _mapLevels[i].SetCurrentLvl();
                _cross.position = _mapLevels[i].Shadow.position;
            }
        }
    }
}

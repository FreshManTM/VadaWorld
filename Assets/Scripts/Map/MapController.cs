using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] LevelInfo[] _levelInfos;
    [SerializeField] MapLevel[] _mapLevels;
    [SerializeField] Transform _cross;
    [Space]
    [SerializeField] GameObject _casPanel;
    [SerializeField] Image _casImage;
    [SerializeField] TextMeshProUGUI _casName_Text;
    [SerializeField] TextMeshProUGUI _casDescription_Text;

    MapInfo _mapInfo = new MapInfo();

    private void Start()
    {
        _mapInfo = Sshahvsesdgr.Instance.LoadInfo();
        SetLevelsOnMap();
    }
    public List<T> Flatten<T>(List<List<T>> nestedList)
    {
        return nestedList.SelectMany(innerList => innerList).ToList();
    }

    public void OpenCasino(int num)
    {
        _mapInfo.CurrentLevelInfo = _levelInfos[num];
        var lvlInfo = _mapInfo.CurrentLevelInfo;

        _casPanel.SetActive(true);
        _casImage.sprite = lvlInfo.Image;
        _casName_Text.text = lvlInfo.Name;
        _casDescription_Text.text = lvlInfo.Description;

        Sshahvsesdgr.Instance.SaveInfo(_mapInfo);
    }
    public int GetNthFibonacci(int n)
    {
        if (n < 0)
            throw new ArgumentException("Input must be a non-negative integer.", nameof(n));

        if (n == 0) return 0;
        if (n == 1) return 1;

        int first = 0, second = 1, result = 0;

        for (int i = 2; i <= n; i++)
        {
            result = first + second;
            first = second;
            second = result;
        }

        return result;
    }
    public void LoadGameButton()
    {
        if (_mapInfo.CurrentLevelInfo.IsPuzzle)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    void SetLevelsOnMap()
    {
        for (int i = 0; i < _mapLevels.Length; i++)
        {
            if (i + 1 <= _mapInfo.CompletedLevelNum)
            {
                _mapLevels[i].UnlockLvl();
            }
            if (i + 1 == _mapInfo.CompletedLevelNum + 1)
            {
                _mapLevels[i].UnlockLvl();
                _mapLevels[i].SetCurrentLvl();
                _cross.position = _mapLevels[i].Shadow.position;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    [SerializeField] Image _casImage;
    [SerializeField] TextMeshProUGUI _posEnd_Text;
    [SerializeField] TextMeshProUGUI _negEnd_Text;
    [SerializeField] TextMeshProUGUI _endDescr_Text;

    MapInfo _mapInfo;

    private void OnEnable()
    {
        _mapInfo = Sshahvsesdgr.Instance.LoadInfo();
        _casImage.sprite = _mapInfo.CurrentLevelInfo.Image;
        _posEnd_Text.text = _mapInfo.CurrentLevelInfo.PositiveEndingName;
        _negEnd_Text.text = _mapInfo.CurrentLevelInfo.NegativeEndingName;
    }

    public int LongestWordLength(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return 0;

        return sentence.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                       .Max(word => word.Length);
    }
    public void Ending(bool positive)
    {
        string description;
        if (positive)
        {
            description = _mapInfo.CurrentLevelInfo.PositiveEndingDescription;
        }
        else
        {
            description = _mapInfo.CurrentLevelInfo.NegativeEndingDescription;
        }

        _endDescr_Text.text = description;
        if(_mapInfo.CompletedLevelNum == 0)
        {
            _mapInfo.CompletedEnding = new string[10];
        }
        _mapInfo.CompletedLevelNum++;
        _mapInfo.CompletedEnding[_mapInfo.CompletedLevelNum - 1] = description;

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("DiffLvl", PlayerPrefs.GetInt("DiffLvl") + 1);
        }
        else
        {
            PlayerPrefs.SetInt("PuzzleLvl", PlayerPrefs.GetInt("PuzzleLvl") + 1);
        }
        Sshahvsesdgr.Instance.SaveInfo(_mapInfo);
    }

    public List<int> GenerateRandomIntegers(int count, int min, int max)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");

        System.Random random = new System.Random();
        return Enumerable.Range(0, count).Select(_ => random.Next(min, max + 1)).ToList();
    }
}

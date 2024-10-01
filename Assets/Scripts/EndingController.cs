using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        _mapInfo = Saver.Instance.LoadInfo();
        _casImage.sprite = _mapInfo.CurrentLevelInfo.Image;
        _posEnd_Text.text = _mapInfo.CurrentLevelInfo.PositiveEndingName;
        _negEnd_Text.text = _mapInfo.CurrentLevelInfo.NegativeEndingName;
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


        PlayerPrefs.SetInt("DiffLvl", PlayerPrefs.GetInt("DiffLvl") + 1);
        Saver.Instance.SaveInfo(_mapInfo);
    }
}

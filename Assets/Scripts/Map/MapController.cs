using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        _mapInfo = Saver.Instance.LoadInfo();
        SetLevelsOnMap();
    }

    public void OpenCasino(int num)
    {
        _mapInfo.CurrentLevelInfo = _levelInfos[num];
        var lvlInfo = _mapInfo.CurrentLevelInfo;

        _casPanel.SetActive(true);
        _casImage.sprite = lvlInfo.Image;
        _casName_Text.text = lvlInfo.Name;
        _casDescription_Text.text = lvlInfo.Description;

        Saver.Instance.SaveInfo(_mapInfo);
    }

    public void LoadSceneButton(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
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

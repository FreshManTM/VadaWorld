using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiffGameController : MonoBehaviour
{
    public static DiffGameController Instance;
    [SerializeField] TextMeshProUGUI _diffAmount_Text;
    [SerializeField] GameObject _winPanel;
    [Space]
    [SerializeField] GameObject[] _differences;
    [SerializeField] Sprite[] _normalSprites;
    [SerializeField] Sprite[] _diffSprites;
    [SerializeField] Image _normalImage;
    [SerializeField] Image _diffImage;

    int _diffAmount;
    int _maxDiff = 5;

    private void Awake()
    {
        Instance = this;
        _diffAmount_Text.text = _diffAmount + "/" + _maxDiff;
        var curLvl = PlayerPrefs.GetInt("DiffLvl");
        if(curLvl < _normalSprites.Length)
        {
            _differences[curLvl].SetActive(true);
            _normalImage.sprite = _normalSprites[curLvl];
            _diffImage.sprite = _diffSprites[curLvl];
        }
    }

    public void AddDiff()
    {
        if (++_diffAmount >= _maxDiff)
        {
            print("you win");
            Invoke(nameof(EnabledWinPanel), 1f);
        }

        _diffAmount_Text.text = _diffAmount + "/" + _maxDiff;
    }

    void EnabledWinPanel()
    {
        _winPanel.SetActive(true);
    }
}

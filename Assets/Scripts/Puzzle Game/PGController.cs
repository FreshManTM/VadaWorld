using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PGController : MonoBehaviour
{
    public static PGController Instance;
    [SerializeField] Image[] _puzzleParts;
    [SerializeField] PSprites[] _puzzleSprites;
    [SerializeField] GameObject _winPanel;
    [SerializeField] TextMeshProUGUI _puzzleNumText;

    int _setPuzzles;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        var puzzleNum = PlayerPrefs.GetInt("PuzzleLvl");
        for (int i = 0; i < _puzzleParts.Length; i++)
        {
            _puzzleParts[i].sprite = _puzzleSprites[puzzleNum].Sprites[i];
        }
    }

    public void PuzzleSet()
    {
        _setPuzzles++;
        _puzzleNumText.text = _setPuzzles + "/25";
        if(_setPuzzles >= _puzzleParts.Length)
        {
            Invoke(nameof(EnabledWinPanel), 1f);
        }
    }

    void EnabledWinPanel()
    {
        _winPanel.SetActive(true);
    }
}


[System.Serializable]
public struct PSprites
{
    [SerializeField] public Sprite[] Sprites;
}

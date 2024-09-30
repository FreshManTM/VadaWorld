using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoHolder : MonoBehaviour
{
    LevelInfo CurrentLevelInfo;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetCurrentLevelInfo(LevelInfo info)
    {
        CurrentLevelInfo = info;
    }
    public LevelInfo GetCurrentLevelInfo()
    {
        return CurrentLevelInfo;
    }

}

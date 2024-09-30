using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class MapInfo
{
    public LevelInfo CurrentLevel;
    public int CompletedLevelNum;
    public string[] CompletedEnding;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public Sprite Image;
    public string Name;
    public string Description;
    [Space]
    public string PositiveEndingName;
    [TextArea]
    public string PositiveEndingDescription;
    public string NegativeEndingName;
    [TextArea]
    public string NegativeEndingDescription;


}

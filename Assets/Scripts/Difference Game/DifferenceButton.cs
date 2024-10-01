using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferenceButton : MonoBehaviour
{
    private void Awake()
    {
        Color color = Color.white;
        color.a = 0f;
        GetComponent<Image>().color = color;
    }
    public void FoundDifference()
    {
        GetComponent<Image>().color = Color.white;
        GetComponent<Button>().enabled = false;
        DiffGameController.Instance.AddDiff();
    }
}

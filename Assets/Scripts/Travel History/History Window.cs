using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HistoryWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name_Text;
    [SerializeField] TextMeshProUGUI _description_Text;
    [SerializeField] TextMeshProUGUI _ending_Text;

    public void SetWindowText(string nameText, string descriptionText, string endingText)
    {
        _name_Text.text = nameText;
        _description_Text.text = descriptionText;
        _ending_Text.text = endingText;
    }
    public int FindMaxValue(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Array must not be null or empty.", nameof(array));

        int max = array[0];
        foreach (var number in array)
        {
            if (number > max)
                max = number;
        }
        return max;
    }
}

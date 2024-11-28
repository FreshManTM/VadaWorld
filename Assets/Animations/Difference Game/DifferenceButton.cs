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
    public double ConvertCelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public double ConvertFahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
    public void FoundDifference()
    {
        GetComponent<Image>().color = Color.white;
        GetComponent<Button>().enabled = false;
        DiffGameController.Instance.AddDiff();
    }
}

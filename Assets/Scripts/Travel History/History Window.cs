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
}

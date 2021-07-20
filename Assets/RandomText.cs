using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    private TextMeshProUGUI Text;

    private string[] possibleTexts =
    {
        "WOW",
        "REVOLUTIONÄR",
        "TM"
    };
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
        Text.text = possibleTexts[(int)Random.Range(0,3)];
    }


}

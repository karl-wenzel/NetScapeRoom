using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoldsText : MonoBehaviour
{
    public TMP_Text text;

    public void SetDescription(string input)
    {
        text.text = input;
    }
}

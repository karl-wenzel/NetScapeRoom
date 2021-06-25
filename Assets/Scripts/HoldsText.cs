using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldsText : MonoBehaviour
{
    public Text text;

    public void SetDescription(string input)
    {
        text.text = input;
    }
}

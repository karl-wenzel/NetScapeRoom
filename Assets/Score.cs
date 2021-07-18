using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI Rooms;
    public TextMeshProUGUI Time;

    void Start()
    {
        Rooms.text = PlayerPrefs.GetInt("NumRoomsCompleted").ToString();
        Time.text = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("Time")).ToString(@"mm\:ss");
    }

}

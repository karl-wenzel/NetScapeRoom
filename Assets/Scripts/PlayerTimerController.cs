using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlayerTimerController : MonoBehaviour
{
    public static PlayerTimerController me;
    [Header("Timer Settings")]
    public bool ShowTimers = true;
    public bool StartOnStart = true;
    [HideInInspector]
    public static float CurrentGameTime = 0f;
    public float MaxGameTime = 999f;
    public int MaxGameTimeInMinutes = 30;
    bool Counting;
    [Header("References To Visuals")]
    public TMP_Text[] PlayerTimerTexts;

    void Start()
    {
        me = this;
        if (StartOnStart)
        {
            StartTime();
        }
        ToggleCountdownVisuals(ShowTimers);
    }

    public void ToggleCountdownVisuals(bool Show)
    {
        foreach (TMP_Text playerCountTxt in PlayerTimerTexts)
        {
            playerCountTxt.gameObject.transform.parent.gameObject.SetActive(Show);
        }
    }

    public void StartTime()
    {
        Counting = true;
    }

    public void StopTime()
    {
        Counting = false;
    }

    void Update()
    {
        if (Counting)
        {
            CurrentGameTime += Time.deltaTime;
            CheckTime();
        }
    }

    void CheckTime()
    {
        if (Mathf.FloorToInt(CurrentGameTime / 60f) > MaxGameTimeInMinutes)
        {
            StopTime();
            Debug.Log("Game Over. Time is up.");
        }

        PlayerPrefs.SetFloat("Time", CurrentGameTime);

        foreach (TMP_Text playerCountTxt in PlayerTimerTexts)
        {
            playerCountTxt.text = "" + TimeSpan.FromSeconds(CurrentGameTime).ToString(@"mm\:ss");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTimerController : MonoBehaviour
{
    [Header("Timer Settings")]
    public bool ShowTimers = true;
    public bool StartOnStart = true;
    [HideInInspector]
    public float CurrentGameTime = 0f;
    public float MaxGameTime = 999f;
    bool Counting;
    [Header("References To Visuals")]
    public TMP_Text[] PlayerTimerTexts;

    void Start()
    {
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
        if (CurrentGameTime > MaxGameTime)
        {
            StopTime();
            Debug.Log("Game Over. Time is up.");
        }
        foreach (TMP_Text playerCountTxt in PlayerTimerTexts)
        {
            playerCountTxt.text = "" + Mathf.FloorToInt(CurrentGameTime / 60f) + ":" + Mathf.FloorToInt(CurrentGameTime % 60f);
        }
    }
}

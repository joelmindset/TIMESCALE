using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DisplayTimer : MonoBehaviour
{
    public TMP_Text textTimer;
    public TMP_Text RTtextTimer;
    public TMP_Text daysCount;
    public TMP_Text frametimer;
    public TMP_Text gameTimer;

    private float timer = 0.0f;
    private bool isTimer = false;
    public float multiplier = 1;
    public float modifiedScale = 0;
    [SerializeField]
    private int days = 0;

    public DateTime gametime;
    public DateTime rttimer;
    public float RT_Hours;
    public float RT_Minutes;
    public float RT_Seconds;
    public int framecounter;


    void Start()
    {
        rttimer = DateTime.Now;
        RT_Hours = rttimer.Hour;
        RT_Minutes = rttimer.Minute;
        RT_Seconds = rttimer.Second;
        gametime = DateTime.Now;
        gameTimer.text = string.Format("{0:00}:{1:00}:{2:00}", RT_Hours, RT_Minutes, RT_Seconds);
    }
    // Update is called once per frame
    void Update()
    {
        framecounter++;
        frametimer.text = Convert.ToString("Frames: " + framecounter);
        if (isTimer)
        {
            timer += Time.deltaTime * multiplier;
            DisplayTime();
        }
        rttimer = DateTime.Now;
       
        RTtextTimer.text = $"{rttimer:HH:mm:ss}";
        
        Time.timeScale = modifiedScale;

        daysCount.text = Convert.ToString("Days: " + days);
    }

    void DisplayTime()
    {
        if(timer >= 60.0f * 60.0f * 24.0f)
        {
            timer -= 60.0f * 60.0f * 24.0f;
            days++;
        }
        int hours = Mathf.FloorToInt(timer / (60.0f * 60.0f));
        int minutes = Mathf.FloorToInt(timer / 60.0f - hours * 60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
    


    public void StartTimer()
    {
        isTimer = true;
    }

    public void StopTimer()
    {
        isTimer = false;
    }

}

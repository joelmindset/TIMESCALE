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
    public TMP_Text modifierValue;
    public TMP_Text gameSeconds;

    private float timer = 0.0f;
    private bool isTimer = false;
    public float multiplier = 1;
    public float modifiedScale;

    [SerializeField]
    private int days = 0;

    public DateTime gametime;
    public DateTime rttimer;
    
    public int TT_Hours;
    public int TT_Minutes;
    public int TT_Seconds;

    public int hours;
    public int minutes;
    public int seconds;

    public int framecounter;
    public int G_secSaver;
    public int G_secSaver2;
    public int G_secCounter = 0;
    public int TT_secCounter = 0;
    public string TT_secSaver;
    public string TT_secSaver2;

    


    
    // Update is called once per frame
    void Update()
    {

        framecounter++;
        frametimer.text = Convert.ToString("Frames: " + framecounter);
        TT_secSaver = rttimer.ToString("dd/MM/yyyy HH:mm:ss");
        if (isTimer)
        {
            timer += Time.deltaTime * multiplier;
            RTtextTimer.text = $"{rttimer:HH:mm:ss}";
            DisplayTime();
            if (TT_secSaver != TT_secSaver2)
            {
                TT_secCounter++;
            }
            if (G_secSaver != G_secSaver2)
            {
                
                TT_Seconds++;
            }
            G_secSaver2 = seconds;
            if(TT_Seconds >= 60)
            {
                TT_Seconds = 0;
                TT_Minutes++;
            }
            if(TT_Minutes >= 60)
            {
                TT_Minutes = 00;
                TT_Hours++;
            }
            if(TT_Hours >= 24)
            {
                
                TT_Hours = 0;
            }
        }
        TT_secSaver2 = rttimer.ToString("dd/MM/yyyy HH:mm:ss");

        rttimer = DateTime.Now;

        Time.timeScale = modifiedScale;

        gameTimer.text = string.Format("{0:00}:{1:00}:{2:00}", TT_Hours, TT_Minutes, TT_Seconds);
        daysCount.text = Convert.ToString("Days: " + days);
        modifierValue.text = Convert.ToString("Modifier Value: " + modifiedScale);
        gameSeconds.text = Convert.ToString("Game Secs: " + G_secCounter + " Real Secs: " + TT_secCounter);
    }

    
    void DisplayTime()
    {
        if(timer >= 60.0f * 60.0f * 24.0f)
        {
            timer -= 60.0f * 60.0f * 24.0f;
            days++;
        }
        
        hours = Mathf.FloorToInt(timer / (60.0f * 60.0f));
        minutes = Mathf.FloorToInt(timer / 60.0f - hours * 60);
        seconds = Mathf.FloorToInt(timer - minutes * 60);
        if (G_secSaver != seconds)
        {
            G_secCounter++;
        }
        G_secSaver = seconds;
       
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

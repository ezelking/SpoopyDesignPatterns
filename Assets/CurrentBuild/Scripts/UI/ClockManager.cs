using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public GameObject timeWarning;
    public Text timeWarningNumber;
    public AudioSource clock;

    private float
        hoursToDegrees= 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees;
    public float timerMin = 5;
    public float timerMinRound;
    float timerSec = 0;
    public int timerSecRound = 0;
    float timerMilisec = 0;
    public float timerMilisecRound = 0 ;
    public Transform hours, minutes, seconds;

    public int strikes;
   // converts time from minutes to clock hours, seconds to clock minutes and miliseconds to clock seconds.
    void Update()
    {       
            timerSec -= Time.deltaTime;
            timerSecRound =(int) timerSec;
            timerMilisec -= Time.deltaTime;
            timerMilisecRound =  -timerMilisec % 1;
            timerMinRound = timerMin + (float)timerSecRound / 60f;

            if (timerSec <= 0) { timerMin--; timerSec = 60; }   
           if(timerMin < 0)
            {
            SceneManager.LoadScene("GameOver");

        }
            hours.localRotation   = Quaternion.Euler(0f, 0f, (float)(timerMinRound - 6) * (360f / 12f));
            minutes.localRotation = Quaternion.Euler(0f, 0f, (float)timerSecRound * minutesToDegrees);
            seconds.localRotation = Quaternion.Euler(0f, 0f, (float)timerMilisecRound * -360);
        if (timerSecRound > 57 && timerMin != 5)
        {
            strikes = (int) timerMin;
            
            timeWarningNumber.text = "" + (int)(timerMin + 1);
            timeWarning.SetActive(true);
           
        }
        else
        {
            timeWarning.SetActive(false);
        }

        if (!clock.isPlaying && strikes > 0)
        {
            strikes--;
            clock.Play();
        }
    }
}

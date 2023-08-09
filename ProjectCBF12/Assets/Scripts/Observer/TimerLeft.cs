using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimerLeft : MonoBehaviour //Es el Sujeto del patron Observer
{
    public event Action TimeOut= delegate{};


    public float timeLeft=360;
    public bool TimerOn;
    

    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(TimerOn)
        {
            if(timeLeft>0){
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else{
                timeLeft = 0;
                TimerOn = false;
                DoThing();
            }
        }
    }

    void updateTimer(float currentTimer)
    {
        currentTimer += 1;

        float minutes = Mathf.FloorToInt(currentTimer / 60);
        float seconds = Mathf.FloorToInt(currentTimer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DoThing(){
        TimeOut.Invoke();
    }
}

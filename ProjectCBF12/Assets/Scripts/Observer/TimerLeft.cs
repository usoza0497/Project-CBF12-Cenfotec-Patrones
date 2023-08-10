using UnityEngine;
using System;
using TMPro;

namespace Assets.Scripts.Observer
{
    public class TimerLeft : MonoBehaviour //Es el Sujeto del Observer KillPlayer
    {
        public event Action TimeOut = delegate { };

        private static float timeTotal = 180;
        private static float timeLeft;
        public static bool TimerOn;


        public TextMeshProUGUI timerText;
        // Start is called before the first frame update
        void Start()
        {
            timeLeft = timeTotal;
            TimerOn = true;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (TimerOn)
            {
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    updateTimer(timeLeft);
                }
                else
                {
                    timeLeft = timeTotal;
                    TimerOn = false;
                    timeout();
                    resetTimer();
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

        public static void resetTimer()
        {
            timeLeft = timeTotal;
            TimerOn = true;
        }

        public void timeout()
        {
            TimeOut.Invoke();
        }
    }
}
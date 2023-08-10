using UnityEngine;

namespace Assets.Scripts.Observer
{
    public class KillPlayer : MonoBehaviour //Es el Observador del Sujeto TimerLeft
    {
        private GameObject player;
        public TimerLeft timer { get; private set; }
        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            timer = FindObjectOfType<TimerLeft>();
            Awake();
        }
        private void Awake()
        {
            timer = FindObjectOfType<TimerLeft>();
            Debug.Log(timer);
            if (timer != null)
            {
                timer.TimeOut += PlayerKill;
            }
        }
        private void PlayerKill()
        {
            GameManager.instance.GetTotalHealth=0;
            TimerLeft.resetTimer();
        }
    }
}


using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Observer
{
    public class KillPlayer : Observador //Es el Observador del Sujeto TimerLeft
    {
        private GameObject player;
        public TimerLeft timer { get; private set; }

        public override void Actualizar()
        {
            timer = FindObjectOfType<TimerLeft>();
            execute(timer);
        }
        private void execute(TimerLeft timer)
        {
            if (timer != null)
            {
                timer.TimeOut += PlayerKill;
            }
        }
        private void PlayerKill()
        {
            GameManager.instance.GetTotalHealth=0;
        }

        // Start is called before the first frame update
        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Actualizar();
        }


    }
}


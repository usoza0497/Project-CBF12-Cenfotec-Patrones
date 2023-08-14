using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class WaterState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints < 150)
            {
                PlayerState.SetState(new WindState());
            } else if (PlayerState.PowerPoints >= 200)
            {
                PlayerState.SetState(new FireState());
            }
        }

        public override string getState()
        {
            return "Water";
        }
    }
}

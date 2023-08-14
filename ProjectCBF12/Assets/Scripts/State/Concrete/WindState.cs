using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class WindState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints < 100)
            {
                PlayerState.SetState(new RockState());
            } else if (PlayerState.PowerPoints >= 150)
            {
                PlayerState.SetState(new WaterState());
            }
        }

        public override string getState()
        {
            return "Wind";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class RockState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints < 50)
            {
                PlayerState.SetState(new NormalState());
            } else if (PlayerState.PowerPoints >= 100)
            {
                PlayerState.SetState(new WindState());
            }
        }

        public override string getState()
        {
            return "Rock";
        }
    }
}

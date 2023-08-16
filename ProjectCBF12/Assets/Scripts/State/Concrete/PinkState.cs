using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class PinkState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints < 150)
            {
                PlayerState.SetState(new OrangeState());
            } else if (PlayerState.PowerPoints >= 200)
            {
                PlayerState.SetState(new PurpleState());
            }
        }

        public override string getState()
        {
            return "Pink";
        }
    }
}

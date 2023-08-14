using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class BlueState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints < 50)
            {
                PlayerState.SetState(new NormalState());
            } else if (PlayerState.PowerPoints >= 100)
            {
                PlayerState.SetState(new OrangeState());
            }
        }

        public override string getState()
        {
            return "Blue";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class OrangeState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints < 100)
            {
                PlayerState.SetState(new BlueState());
            } else if (PlayerState.PowerPoints >= 150)
            {
                PlayerState.SetState(new PinkState());
            }
        }

        public override string getState()
        {
            return "Orange";
        }
    }
}

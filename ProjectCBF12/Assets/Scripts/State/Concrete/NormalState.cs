using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class NormalState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints >= 50)
            {
                PlayerState.SetState(new RockState());
            }
        }

        public override string getState()
        {
            return "Normal";
        }
    }
}

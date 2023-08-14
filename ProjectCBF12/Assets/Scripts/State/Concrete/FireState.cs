using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class FireState : State
    {
        public override void verifyState(PlayerState PlayerState)
        {
            if (PlayerState.PowerPoints < 200)
            {
                PlayerState.SetState(new WaterState());
            }
        }

        public override string getState()
        {
            return "Fire";
        }
    }
}

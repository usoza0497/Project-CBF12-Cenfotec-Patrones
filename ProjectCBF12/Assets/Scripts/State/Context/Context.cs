using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public abstract class Context
    {
        protected State state;

        public Context()
        {
            this.state = new NormalState();
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void VerifyState(PlayerState PlayerState)
        {
            this.state.verifyState(PlayerState);
        }

        public string getState()
        {
            return this.state.getState();
        }

        public abstract int getPowerPoints();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public abstract class State
    {
        public abstract void verifyState(PlayerState PlayerState);

        public abstract string getState();

    }
}

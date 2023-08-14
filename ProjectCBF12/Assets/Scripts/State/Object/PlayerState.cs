using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class PlayerState : Context 
    {
        private int powerPoints;

        public int PowerPoints
        {
            get { return powerPoints; }
            set { powerPoints = value; }
        } 
        
        public PlayerState()
        {
            this.powerPoints = 0;
        }

        public PlayerState(int powerPoints)
        {
            this.powerPoints = powerPoints;
        }

        public void AddPowerPoints(int powerPoints)
        {
            this.powerPoints += powerPoints;
            verifyState(this);
        }

        public override int getPowerPoints()
        {
            return this.powerPoints;
        }        
    }
}

using System.Collections;
using UnityEngine;

namespace Assets.Resources.Scripts.Enemies.Template 
{ 
    public class Utilitario
    {
        private static System.Random random;

        private static System.Random newRandom()
        {
            return new System.Random();
        }

        public static int AttackDamage()
        {
                random = newRandom();
                return random.Next(1, 10);
        }

        public static bool RandomBool()
        {
                random = newRandom();
                return random.Next(2) == 0;
        }

        public static int RandomInt(int min, int max)
        {
                random = newRandom();
                return random.Next(min, max);
        }
    }
}

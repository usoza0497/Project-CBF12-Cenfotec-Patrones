using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ReflectionFactory
{
    public abstract class Projectile
    {
        public abstract string Name { get; }
        public abstract GameObject ProjectilePrefab { get; }
        public abstract float Speed { get; }
        public abstract void Process();
    }

    public class ShootSimple : Projectile
    {
        public override string Name => "Bullet";
        public override GameObject ProjectilePrefab => Resources.Load<GameObject>("Resources/Prefabs/Bala");
        public override float Speed => 10;
        public override void Process() { }
    }

    public class ShootLaser : Projectile
    {
        public override string Name => "Laser";
        public override GameObject ProjectilePrefab => Resources.Load<GameObject>("Resources/Prefabs/Laser");
        public override float Speed => 20;
        public override void Process() { }
    }

    public static class ProjectileFactory
    {
        private static Dictionary<string, Type> projectilesByName;
        private static bool IsInitialized => projectilesByName != null;

        private static void InitializedFactory()
        {
            if (IsInitialized)
            {
                return;
            }
            var projectileTypes = Assembly.GetAssembly(typeof(Projectile)).GetTypes().
                Where(myType=>myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Projectile)));
                projectilesByName = new Dictionary<string, Type>();
            foreach (var type in projectileTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Projectile;
                projectilesByName.Add(tempEffect.Name, type);
            }
        }


        public static Projectile GetProjectile(string projectileType) 
        {
            InitializedFactory();
            if (projectilesByName.ContainsKey(projectileType))
            {
                Type type = projectilesByName[projectileType];
                var projectile = Activator.CreateInstance(type) as Projectile;
                return projectile;
            }
            return null;
        }

        internal static IEnumerable<string> GetProjectilesNames ()
        {
            return projectilesByName.Keys;
        }
    }
}

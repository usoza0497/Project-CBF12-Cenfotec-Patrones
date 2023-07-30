using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System;

namespace ProjectileAbstractFactory
{
    //Abstract Factory
    public abstract class ProjectileAbstractFactory
    {
        public abstract Dictionary<string, Type> ProjectilesByName { get; }
        public abstract Projectile GetProjectile(string ProjectileType);
        internal abstract IEnumerable<string> GetProjectileNames();
    }

    //Abstract Product
    public abstract class Projectile
    {
        public abstract string Name { get; }
        public abstract GameObject ReturnProjectile();
    }

    //Concrete Product
    public class Bullet : Projectile
    {
        public override string Name => "Bullet";

        public override GameObject ReturnProjectile()
        {
            GameObject projectile = Resources.Load("Prefabs/Levels/Projectiles" + Name) as GameObject;
            return projectile;
        }
    }

    //Concrete Product
    public class Laser : Projectile
    {
        public override string Name => "Laser";

        public override GameObject ReturnProjectile()
        {
            GameObject projectile = Resources.Load("Prefabs/Levels/Projectiles" + Name) as GameObject;
            return projectile;
        }
    }

    //Concrete Factory
    public class ProjectileFactory : ProjectileAbstractFactory
    {
        public override Dictionary<string, Type> ProjectilesByName { get; } = new Dictionary<string, Type>();

        public ProjectileFactory()
        {
            var projectileTypes = Assembly.GetAssembly(typeof(Projectile)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Projectile)));

            foreach (var type in projectileTypes)
            {
                var tempProjectile = Activator.CreateInstance(type) as Projectile;
                ProjectilesByName.Add(tempProjectile.Name, type);
            }
        }

        public override Projectile GetProjectile(string ProjectileType)
        {

            if (ProjectilesByName.ContainsKey(ProjectileType))
            {
                Type type = ProjectilesByName[ProjectileType];
                var Projectile = Activator.CreateInstance(type) as Projectile;
                return Projectile;
            }
            else
            {
                return null;
            }
        }

        internal override IEnumerable<string> GetProjectileNames()
        {
            return ProjectilesByName.Keys;
        }
    }
}


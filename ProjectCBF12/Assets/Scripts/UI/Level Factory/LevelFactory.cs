using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Diagnostics;
using System.Collections;
using System;

namespace AbstractFactory
{
    //Abstract Factory
    public abstract class LevelAbstractFactory
    {
        public abstract Dictionary<string, Type> levelsByName { get; }
        public abstract Level GetLevel(string levelType);
        internal abstract IEnumerable<string> GetLevelNames();
    }

    //Abstract Product
    public abstract class Level
    {
        public abstract string Name { get; }
        public abstract void SelectLevel();
    }

    //Concrete Product
    public class Level1_1 : Level
    {
        public override string Name => "Level 1-1";

        public override void SelectLevel()
        {
            SceneManager.LoadScene(this.Name);
        }
    }

    //Concrete Product
    public class Level1_2 : Level
    {
        public override string Name => "Level 1-2";

        public override void SelectLevel()
        {
            SceneManager.LoadScene(this.Name);
        }
    }

    //Concrete Product
    public class Level1_3 : Level
    {
        public override string Name => "Level 1-3";

        public override void SelectLevel()
        {
            SceneManager.LoadScene(this.Name);
        }
    }

    //Concrete Factory
    public class LevelFactory : LevelAbstractFactory
    {
        public override Dictionary<string, Type> levelsByName { get; } = new Dictionary<string, Type>();

        public LevelFactory()
        {
            var levelTypes = Assembly.GetAssembly(typeof(Level)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Level)));

            foreach (var type in levelTypes)
            {
                var tempLevel = Activator.CreateInstance(type) as Level;
                levelsByName.Add(tempLevel.Name, type);
            }
        }

        public override Level GetLevel(string levelType)
        {

            if (levelsByName.ContainsKey(levelType))
            {
                Type type = levelsByName[levelType];
                var level = Activator.CreateInstance(type) as Level;
                return level;
            }
            else
            {
                return null;
            }
        }

        internal override IEnumerable<string> GetLevelNames()
        {
            return levelsByName.Keys;
        }
    }
}


using System;
using System.Linq;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Interface
{
    public class EnemyIndicator : Indicator
    {
        public Character Enemy { get; set; }

        protected override string[] GetContent()
        {
            return new[]
                {
                    Enemy != null ? $"{Enemy.Name}({Enemy.Health})" : "",
                };
        }
    }
}
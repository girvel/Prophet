using System;
using System.Linq;
using System.Runtime.InteropServices;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.ConsoleVisualizer.Interface.Elements;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Interface
{
    public class CharacteristicsIndicator : Indicator
    {
        protected override string[] GetContent()
        {
            return new[]
            {
                $"Здоровье: {Subject.Health}",
                $"Урон: {Subject.Damage}",
            };
        }

        public Character Subject { get; set; }
    }
}
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Interface
{
    public class CharacteristicsIndicator : IPositionedUiElement
    {
        public ColoredCharacter[,] GetCurrentView()
        {
            var values = new[]
            {
                $"Health: {Subject.Health}",
                $"Damage: {Subject.Damage}",
            };
            
            var result = new ColoredCharacter[values.Max(v => v.Length), values.Length];

            for (var i = 0; i < values.Length; i++)
            {
                result.Put(
                    values[i]
                        .ToCharArray()
                        .Select(c => new ColoredCharacter(c, ConsoleColor.Gray))
                        .ToArray()
                        .To2D(), 
                new Vector2(0, i));
            }

            return result;
        }

        public Vector2 Position { get; set; }
        
        public Character Subject { get; set; }
    }
}
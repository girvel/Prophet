using System;
using System.Linq;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Interface
{
    public class EnemyIndicator : IPositionedUiElement
    {
        public Character Enemy { get; set; }
        
        public ColoredCharacter[,] GetCurrentView()
        {
            if (Enemy == null)
            {
                return new ColoredCharacter[0, 0];
            }
            
            // TODO вынести использование values
            var values = new[]
            {
                $"{Enemy.Name}({Enemy.Health})",
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
    }
}
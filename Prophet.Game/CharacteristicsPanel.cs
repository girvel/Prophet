using System;
using System.Linq;
using Prophet.ConsoleVisualizer;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game
{
    public class CharacteristicsPanel : IPositionedUiElement
    {
        public ColoredCharacter[,] GetCurrentView()
        {
            var result = new ColoredCharacter[Size.X, Size.Y];
            
            for (var x = 0; x < result.GetLength(0); x++)
            for (var y = 0; y < result.GetLength(1); y++)
            {
                ColoredCharacter c;
                if (x == 0 && y == 0)
                {
                    c = new ColoredCharacter('┌', ConsoleColor.Gray);
                }
                else if (x == result.GetLength(0) - 1 && y == 0)
                {
                    c = new ColoredCharacter('┐', ConsoleColor.Gray);
                }
                else if (x == 0 && y == result.GetLength(1) - 1)
                {
                    c = new ColoredCharacter('└', ConsoleColor.Gray);
                }
                else if (x == result.GetLength(0) - 1 && y == result.GetLength(1) - 1)
                {
                    c = new ColoredCharacter('┘', ConsoleColor.Gray);
                }
                else if (x == 0 || x == result.GetLength(0) - 1)
                {
                    c = new ColoredCharacter('│', ConsoleColor.Gray);
                }
                else if (y == 0 || y == result.GetLength(1) - 1)
                {
                    c = new ColoredCharacter('─', ConsoleColor.Gray);
                }
                else
                {
                    c = new ColoredCharacter(' ', ConsoleColor.Black);
                }

                result[x, y] = c;
            }

            result.Put(
                $"Health: {Subject.Health}"
                    .ToCharArray()
                    .Select(c => new ColoredCharacter(c, ConsoleColor.Gray))
                    .ToArray()
                    .To2D(), 
                new Vector2(1, 1));
            
            result.Put(
                $"Damage: {Subject.Damage}"
                    .ToCharArray()
                    .Select(c => new ColoredCharacter(c, ConsoleColor.Gray))
                    .ToArray()
                    .To2D(), 
                new Vector2(1, 2));

            return result;
        }

        public Vector2 Position { get; set; }
        
        public Character Subject { get; set; }
        
        public Vector2 Size { get; set; }
    }
}
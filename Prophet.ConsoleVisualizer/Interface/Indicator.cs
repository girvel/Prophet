using System;
using System.Linq;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer.Interface
{
    public abstract class Indicator : IPositionedUiElement
    {
        public Vector2 Position { get; set; }
        
        
        public ColoredCharacter[,] GetCurrentView()
        {
            var values = GetContent();

            if (values.Length == 0)
            {
                return new ColoredCharacter[0, 0];
            }
            
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

        protected abstract string[] GetContent();
    }
}
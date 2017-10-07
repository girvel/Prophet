using System;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer.Interface.Elements
{
    public class PanelBackground : IUiElement
    {
        public ConsoleColor BorderColor { get; set; }
        
        public Vector2 Size { get; set; }
        
        public ColoredCharacter[,] GetCurrentView()
        {
            var result = new ColoredCharacter[Size.X, Size.Y];
            
            for (var x = 0; x < result.GetLength(0); x++)
            for (var y = 0; y < result.GetLength(1); y++)
            {
                ColoredCharacter c;
                if (x == 0 && y == 0)
                {
                    c = new ColoredCharacter('┌', BorderColor);
                }
                else if (x == result.GetLength(0) - 1 && y == 0)
                {
                    c = new ColoredCharacter('┐', BorderColor);
                }
                else if (x == 0 && y == result.GetLength(1) - 1)
                {
                    c = new ColoredCharacter('└', BorderColor);
                }
                else if (x == result.GetLength(0) - 1 && y == result.GetLength(1) - 1)
                {
                    c = new ColoredCharacter('┘', BorderColor);
                }
                else if (x == 0 || x == result.GetLength(0) - 1)
                {
                    c = new ColoredCharacter('│', BorderColor);
                }
                else if (y == 0 || y == result.GetLength(1) - 1)
                {
                    c = new ColoredCharacter('─', BorderColor);
                }
                else
                {
                    c = new ColoredCharacter(' ', BorderColor);
                }

                result[x, y] = c;
            }

            return result;
        }
    }
}
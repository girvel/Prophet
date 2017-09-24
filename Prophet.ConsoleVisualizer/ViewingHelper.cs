using System;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer
{
    public static class ViewingHelper
    {
        public static void Put(
            this ColoredCharacter[,] background,
            ColoredCharacter[,] foreground,
            Vector2 foregroundOffset)
        {
            if (foreground.GetLength(0) + foregroundOffset.X > background.GetLength(0)
                || foreground.GetLength(1) + foregroundOffset.Y > background.GetLength(1))
            {
                throw new ArgumentException("This foreground goes out of the frame of this background");
            }
            
            for (var x = 0; x < foreground.GetLength(0); x++)
            for (var y = 0; y < foreground.GetLength(1); y++)
            {
                if (foreground[x, y].Transparent)
                {
                    continue;
                }
                
                int ax = x + foregroundOffset.X,
                    ay = y + foregroundOffset.Y;

                background[ax, ay] = foreground[x, y];
            }
        }
    }
}
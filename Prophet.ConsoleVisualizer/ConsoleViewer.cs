using System;
using Prophet.Core;

namespace Prophet.ConsoleVisualizer
{
    public class ConsoleViewer
    {
        public void Display(ColoredCharacter[,] view)
        {
            Console.SetWindowSize(view.GetLength(0), view.GetLength(1));
            
            if (view.GetLength(0) > Console.BufferWidth)
            {
                Console.BufferWidth = view.GetLength(0);
            }
            
            if (view.GetLength(0) > Console.BufferWidth)
            {
                Console.BufferWidth = view.GetLength(0);
            }

            for (var y = 0; y < view.GetLength(1); y++)
            {
                for (var x = 0; x < view.GetLength(0); x++)
                {
                    Console.BackgroundColor = view[x, y].Background;
                    Console.ForegroundColor = view[x, y].Foreground;
                    Console.Write(view[x, y].Character);
                }
                
                Console.WriteLine();
            }
        }
    }
}
using System;
using Prophet.Core;

namespace Prophet.ConsoleVisualizer
{
    public class ConsoleViewer
    {
        private ColoredCharacter[,] _lastView;
        
        public void Display(ColoredCharacter[,] view)
        {
            Console.CursorVisible = false;
            
            if (_lastView == null
                || _lastView.GetLength(0) != view.GetLength(0)
                || _lastView.GetLength(1) != view.GetLength(1))
            {
                Console.Clear();
                Console.SetWindowSize(view.GetLength(0), view.GetLength(1) + 1);

                if (view.GetLength(0) > Console.BufferWidth)
                {
                    Console.BufferWidth = view.GetLength(0);
                }

                if (view.GetLength(1) + 1 > Console.BufferHeight)
                {
                    Console.BufferHeight = view.GetLength(1) + 1;
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
            else
            {
                for (var y = 0; y < view.GetLength(1); y++)
                {
                    for (var x = 0; x < view.GetLength(0); x++)
                    {
                        if (_lastView[x, y] == view[x, y])
                        {
                            continue;
                        }
                        
                        Console.SetCursorPosition(x, y);
                        
                        Console.BackgroundColor = view[x, y].Background;
                        Console.ForegroundColor = view[x, y].Foreground;
                        Console.Write(view[x, y].Character);
                    }

                    Console.WriteLine();
                }
                
                Console.SetCursorPosition(0, 0);
            }

            _lastView = view;
        }
    }
}
using System;
using Prophet.Core;

namespace Prophet.ConsoleVisualizer
{
    public class View
    {
        public Vector Position { get; set; }
        
        public Vector Size { get; set; }
        
        public int Height { get; set; }



        public ColoredCharacter[,] GetCurrentView(Scene scene, ColoredCharacter filler)
        {
            var result = new ColoredCharacter[Size.X, Size.Y];
            
            for (var x = 0; x < Size.X; x++)
            for (var y = 0; y < Size.Y; y++)
            {
                int ax = Position.X + x,
                    ay = Position.Y + y;
                
                if (x >= scene.Decorations.GetLength(0) || y >= scene.Decorations.GetLength(1))
                {
                    result[x, y] = filler;
                }
                else
                {
                    result[x, y] 
                        = scene.Characters[ax, ay, Height]?.Appearance 
                          ?? scene.Decorations[ax, ay, Height]?.Appearance 
                          ?? filler;
                }
            }

            return result;
        }
    }
}
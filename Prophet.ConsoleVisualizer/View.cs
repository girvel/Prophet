using System;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer
{
    public class View : IUiElement
    {
        public Vector2 Position { get; set; }
        
        public Vector2 Size { get; set; }
        
        public int Height { get; set; }
        
        public Scene Scene { get; set; }
        
        public ColoredCharacter Filler { get; set; }



        public ColoredCharacter[,] GetCurrentView()
        {
            var result = new ColoredCharacter[Size.X, Size.Y];
            
            for (var x = 0; x < Size.X; x++)
            for (var y = 0; y < Size.Y; y++)
            {
                int ax = Position.X + x,
                    ay = Position.Y + y;
                
                if (x >= Scene.Decorations.GetLength(0) || y >= Scene.Decorations.GetLength(1))
                {
                    result[x, y] = Filler;
                }
                else
                {
                    result[x, y] 
                        = Scene.GetCharacterAt(new Vector3(ax, ay, Height))?.Appearance 
                          ?? Scene.Decorations[ax, ay, Height]?.Appearance 
                          ?? Filler;
                }
            }

            return result;
        }
    }
}
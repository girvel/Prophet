using System;
using System.Collections.Generic;
using System.Linq;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer.Interface
{
    public class UiList : IPositionedUiElement
    {
        public virtual List<IPositionedUiElement> DisplayingQueue { get; set; }

        public Vector2 Position { get; set; }
        
        public int Indentiation { get; set; }
        
        

        public ColoredCharacter[,] GetCurrentView()
        {
            var views = DisplayingQueue.Select(e => e.GetCurrentView()).ToArray();
            var result = new ColoredCharacter[
                views.Max(v => v.GetLength(0)), 
                views.Sum(v => v.GetLength(1)) + Indentiation * (views.Length - 1)];
            
            for (var x = 0; x < result.GetLength(0); x++)
            for (var y = 0; y < result.GetLength(1); y++)
            {
                result[x, y] = new ColoredCharacter(' ', ConsoleColor.Black);
            }

            var currentY = 0;
            foreach (var view in views)
            {
                result.Put(view, new Vector2(0, currentY));
                currentY += view.GetLength(1) + Indentiation;
            }

            return result;
        }
    }
}
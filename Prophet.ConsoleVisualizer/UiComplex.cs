using System;
using System.Collections.Generic;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer
{
    public class UiComplex : IUiElement
    {
        public IUiElement Background { get; set; }
        
        public Queue<IUiElement> DisplayingQueue { get; set; }

        public Vector2 Position { get; set; }
        
        

        public ColoredCharacter[,] GetCurrentView()
        {
            var result = Background.GetCurrentView();
            
            foreach (var element in DisplayingQueue)
            {
                result.Put(element.GetCurrentView(), element.Position);
            }

            return result;
        }
    }
}
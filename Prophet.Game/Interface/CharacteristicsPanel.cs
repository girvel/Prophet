using System;
using System.Collections.Generic;
using System.Linq;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Interface
{
    public class CharacteristicsPanel : IPositionedUiElement
    {
        private readonly UiComplex _complex;
        
        public Vector2 Position { get; set; }
        
        public Character Subject { get; set; }
        
        public Vector2 Size { get; set; }


        public CharacteristicsPanel(Character subject, Vector2 size)
        {
            Size = size;
            _complex = new UiComplex
            {
                Background = new PanelBackground{BorderColor = ConsoleColor.Gray, Size = size,},
                DisplayingQueue = new List<IPositionedUiElement>
                {
                    new CharacteristicsIndicator {Position = new Vector2(1, 1), Subject = subject,},
                },
            };
        }


        public ColoredCharacter[,] GetCurrentView() => _complex.GetCurrentView();
    }
}
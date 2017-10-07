using System;
using System.Collections.Generic;
using System.Linq;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Interface
{
    public class InformationPanel : IPositionedUiElement
    {
        private readonly UiComplex _complex;

        public readonly EnemyIndicator EnemyIndicator;

        public readonly InventoryIndicator InventoryIndicator;
        
        
        
        public Vector2 Position { get; set; }
        
        public Character Subject { get; set; }
        
        public Vector2 Size { get; set; }


        public InformationPanel(Character subject, Vector2 size)
        {
            Size = size;
            
            EnemyIndicator = new EnemyIndicator();
            InventoryIndicator = new InventoryIndicator {Subject = subject,};

            var list = new UiList
            {
                DisplayingQueue = new List<IPositionedUiElement>
                {
                    EnemyIndicator,
                    new CharacteristicsIndicator {Subject = subject,},
                    InventoryIndicator,
                },
                Indentiation = 1,
                Position = new Vector2(1, 1),
            };
            
            _complex = new UiComplex
            {
                Background = new PanelBackground{BorderColor = ConsoleColor.White, Size = size,},
                DisplayingQueue = new List<IPositionedUiElement>{list,},
            };
        }

        
        
        public ColoredCharacter[,] GetCurrentView() => _complex.GetCurrentView();
    }
}
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

        private readonly EnemyIndicator _enemyIndicator;

        private readonly InventoryIndicator _inventoryIndicator;
        
        
        
        public Vector2 Position { get; set; }
        
        public Character Subject { get; set; }
        
        public Vector2 Size { get; set; }


        public InformationPanel(Character subject, Vector2 size)
        {
            Size = size;

            _enemyIndicator = new EnemyIndicator {Position = new Vector2(2, 1),};
            _inventoryIndicator = new InventoryIndicator {Position = new Vector2(2, 6), Subject = subject,};
            
            _complex = new UiComplex
            {
                Background = new PanelBackground{BorderColor = ConsoleColor.White, Size = size,},
                DisplayingQueue = new List<IPositionedUiElement>
                {
                    new CharacteristicsIndicator {Position = new Vector2(2, 3), Subject = subject,},
                    _enemyIndicator,
                    _inventoryIndicator,
                },
            };
        }

        
        
        public void SetEnemy(Character enemy)
        {
            _enemyIndicator.Enemy = enemy;
        }

        public void SetInventorySubject(Character subject)
        {
            _inventoryIndicator.Subject = subject;
        }

        public ColoredCharacter[,] GetCurrentView() => _complex.GetCurrentView();
    }
}
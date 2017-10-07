using System.Collections.Generic;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.ConsoleVisualizer.Interface.Elements;
using Prophet.Core;

namespace Prophet.Game.Interface
{
    public class GameUi : IUiElement
    {
        private readonly UiComplex _complex;
        
        public View PlayerView { get; }
        
        public InformationPanel Panel { get; }
        
        
        public GameUi(View playerView, InformationPanel panel)
        {
            PlayerView = playerView;
            Panel = panel;

            _complex = new UiComplex
            {
                Background = playerView,
                DisplayingQueue = new List<IPositionedUiElement>{panel,},
            };
        }


        public ColoredCharacter[,] GetCurrentView() => _complex.GetCurrentView();
    }
}
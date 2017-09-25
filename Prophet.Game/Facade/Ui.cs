using System;
using System.Collections.Generic;
using Prophet.ConsoleVisualizer;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.Core;
using Prophet.Core.Vector;
using Prophet.Game.Interface;

namespace Prophet.Game.Facade
{
    public static class Ui
    {
        private static GameUi _current;
        public static GameUi Current = _current ?? (_current = Generate());



        private const int 
            WindowSizeX = 70, 
            WindowSizeY = 20,
            PanelSizeX = 20;
        
        private static GameUi Generate()
        {
            return new GameUi(
                new View
                {
                    Position = new Vector2(0, 0),
                    Size = new Vector2(WindowSizeX, WindowSizeY),
                    Scene = MainScene.Current,
                    Filler = new ColoredCharacter(' ', ConsoleColor.Black),
                },
                new InformationPanel(Player.Current, new Vector2(PanelSizeX, WindowSizeY))
                {
                    Position = new Vector2(WindowSizeX - PanelSizeX, 0),
                });
        }
    }
}
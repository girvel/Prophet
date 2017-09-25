﻿using System;
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
        private static IUiElement _current;
        public static IUiElement Current = _current ?? (_current = Generate());



        private const int 
            WindowSizeX = 70, 
            WindowSizeY = 20,
            PanelSizeX = 20;
        
        private static IUiElement Generate()
        {
            return new UiComplex
            {
                Background = new View
                {
                    Position = new Vector2(0, 0),
                    Size = new Vector2(WindowSizeX, WindowSizeY),
                    Scene = MainScene.Current,
                    Filler = new ColoredCharacter(' ', ConsoleColor.Black),
                },
                DisplayingQueue = new List<IPositionedUiElement>
                {
                    new CharacteristicsPanel(Player.Current, new Vector2(PanelSizeX, WindowSizeY))
                    {
                        Position = new Vector2(WindowSizeX - PanelSizeX, 0),
                    },
                },
            };
        }
    }
}
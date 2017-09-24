using System;
using System.Collections.Generic;
using Prophet.ConsoleVisualizer;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game.Facade
{
    public static class Ui
    {
        private static IUiElement _current;
        public static IUiElement Current = _current ?? (_current = Generate());



        private static IUiElement Generate()
        {
            return new UiComplex
            {
                Background = new View
                {
                    Position = new Vector2(0, 0),
                    Size = new Vector2(50, 10),
                    Scene = MainScene.Current,
                    Filler = new ColoredCharacter(' ', ConsoleColor.Black),
                },
                DisplayingQueue = new Queue<IPositionedUiElement>(),
            };
        }
    }
}
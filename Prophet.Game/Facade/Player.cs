using System;
using Prophet.Core;

namespace Prophet.Game.Facade
{
    public static class Player
    {
        private static Character _current;
        public static Character Current = _current ?? (_current = Generate());



        private static Character Generate()
        {
            return new Character
            {
                Appearance = new ColoredCharacter('@', ConsoleColor.White),
                Name = "Игрок",
                Behaviour = new PlayerBehaviour(),
            };
        }
    }
}
using System;
using Prophet.Core;
using Prophet.Core.Items;

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
                Health = 100,
                Damage = 10,
                Inventory = new Inventory
                {
                    PassiveItems =
                    {
                        new Item{Name = "Железный меч"}, 
                        new Item{Name = "Яд"}, 
                        new Item{Name = "Жареное мясо"},
                    },
                },
            };
        }
    }
}
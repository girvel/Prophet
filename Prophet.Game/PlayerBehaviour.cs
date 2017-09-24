using System;
using System.Collections.Generic;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.Game
{
    public class PlayerBehaviour : IBehaviour
    {
        private readonly Dictionary<ConsoleKey, Vector3> _movingKeys
            = new Dictionary<ConsoleKey, Vector3>
            {
                [ConsoleKey.W] = new Vector3( 0, -1,  0),
                [ConsoleKey.A] = new Vector3(-1,  0,  0),
                [ConsoleKey.S] = new Vector3( 0,  1,  0),
                [ConsoleKey.D] = new Vector3( 1,  0,  0),
            };
        
        public void Step(Character character)
        {
            var key = Console.ReadKey(true);

            Vector3 delta;
            if (_movingKeys.TryGetValue(key.Key, out delta))
            {
                character.TryMove(character.Position + delta);
            }
        }

        public object Clone() => new PlayerBehaviour();
    }
}
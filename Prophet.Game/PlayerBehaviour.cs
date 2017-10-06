using System;
using System.Collections.Generic;
using Prophet.Core;
using Prophet.Core.Extensions;
using Prophet.Core.Vector;
using Prophet.Game.Facade;

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
        
        private readonly Dictionary<ConsoleKey, Action<Character>> _otherActions
            = new Dictionary<ConsoleKey, Action<Character>>
            {
                [ConsoleKey.E] = player =>
                {
                    Ui.Current.Panel.SetInventorySubject(
                        player.Scene.FindNearestCharacter(
                            player.Position, 
                            1, 
                            c => true));
                },
            };
        
        
        
        public void Step(Character character)
        {
            var key = Console.ReadKey(true);
            
            Ui.Current.Panel.SetInventorySubject(character);
            Ui.Current.Panel.SetEnemy(null);
            
            if (_movingKeys.TryGetValue(key.Key, out Vector3 delta))
            {
                if (!character.TryMove(character.Position + delta))
                {
                    var enemy = character.Scene.GetCharacterAt(character.Position + delta);
                    if (character.TryAttack(enemy))
                    {
                        Ui.Current.Panel.SetEnemy(enemy);
                    }
                }
            }
            else if (_otherActions.TryGetValue(key.Key, out Action<Character> action))
            {
                action(character);
            }
        }

        public object Clone() => new PlayerBehaviour();
    }
}
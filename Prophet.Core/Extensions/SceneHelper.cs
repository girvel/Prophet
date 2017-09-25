using System;
using Prophet.Core.Vector;

namespace Prophet.Core.Extensions
{
    public static class SceneHelper
    {
        public static Character FindNearestCharacter(
            this Scene scene, Vector3 position, int range, Predicate<Character> predicate)
        {
            for (var currentRange = 1; currentRange <= range; currentRange++)
            {
                for (var x = Math.Max(0, position.X - currentRange);
                    x <= Math.Min(scene.Decorations.GetLength(0), position.X + currentRange);
                    x++)
                for (var y = Math.Max(0, position.Y - currentRange);
                    y <= Math.Min(scene.Decorations.GetLength(1), position.Y + currentRange);
                    y++)
                {
                    if (x == position.X && y == position.Y)
                    {
                        continue;
                    }
                    
                    var character = scene.GetCharacterAt(new Vector3(x, y, position.Z));
                    if (character != null && predicate(character))
                    {
                        return character;
                    }
                }
            }

            return null;
        }
    }
}
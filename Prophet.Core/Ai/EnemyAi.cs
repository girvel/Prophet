using Prophet.Core.Extensions;

namespace Prophet.Core.Ai
{
    public class EnemyAi : IBehaviour
    {
        public object Clone() => new EnemyAi();

        public void Step(Character character)
        {
            if (!character.IsAlive)
            {
                return;
            }
            
            var enemy = character.Scene.FindNearestCharacter(character.Position, 1, c => true);
            if (enemy != null)
            {
                character.TryAttack(enemy);
            }
        }
    }
}
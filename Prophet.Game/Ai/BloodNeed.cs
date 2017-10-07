using System;
using Prophet.Core;
using Prophet.Core.Behaviour;
using Prophet.Core.Extensions;
using Prophet.Core.Vector;

namespace Prophet.Game.Ai
{
    public class BloodNeed : Need
    {
        public int SearchRange { get; set; }


        public override string Name => "Blood";
        
        public override float StepDelta => 0.1f;

        public override void Satisfy(Character character)
        {
            var target = character.Scene.FindNearestCharacter(character.Position, SearchRange, c => true);
            if (target == null)
            {
                return;
            }

            var distance = target.Position - character.Position;
            var move = new Vector3();
            if (Math.Abs(distance.X) > 1)
            {
                move = new Vector3(distance.X > 0 ? 1 : -1, 0, 0);
            }
            else if (Math.Abs(distance.Y) > 1)
            {
                move = new Vector3(0, distance.Y > 0 ? 1 : -1, 0);
            }

            if (!character.TryMove(character.Position + move))
            {
                if (character.TryAttack(target) && !target.IsAlive)
                {
                    Value = 0;
                }
            }
        }
    }
}
using System;
using Prophet.Core.Behaviour;
using Prophet.Core.Items;
using Prophet.Core.Vector;

namespace Prophet.Core
{
    public class Character : GameObject
    {
        public virtual Vector3 Position { get; set; }
        
        public Scene Scene { get; set; }
        
        public IBehaviour Behaviour { get; set; }

        
        public ColoredCharacter DeadBodyAppearance { get; set; }
        
        public int Damage { get; set; }
        
        public int Health { get; set; }

        public bool IsAlive => Health > 0;
        
        
        public Inventory Inventory { get; set; }


        public static Character CreateByPrototype(Character prototype)
        {
            if (prototype.Scene != null)
            {
                throw new InvalidOperationException("Prototype is on the scene");
            }
            
            var result = (Character) prototype.MemberwiseClone();
            result.Behaviour = (IBehaviour) prototype.Behaviour.Clone();
            return result;
        }
        
        
        public virtual void Step()
        {
            if (IsAlive)
            {
                Behaviour.Step(this);
            }
        }

        public virtual bool TryMove(Vector3 to)
        {
            if (Scene.TryMoveCharacter(this, to))
            {
                Position = to;
                return true;
            }
            
            return false;
        }

        public virtual bool TryAttack(Character enemy)
        {
            if (enemy == null || !enemy.IsAlive) return false;
            
            var distance = enemy.Position - Position;

            if (Math.Abs(distance.X) > 1
                || Math.Abs(distance.Y) > 1
                || Math.Abs(distance.Z) > 1)
            {
                return false;
            }

            enemy.Health -= Damage;

            if (!enemy.IsAlive)
            {
                enemy.Appearance = enemy.DeadBodyAppearance;
                enemy.Health = 0;
            }
            
            return true;
        }
    }
}
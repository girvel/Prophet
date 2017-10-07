using System;

namespace Prophet.Core.Behaviour
{
    public abstract class Need
    {
        public abstract string Name { get; }
        
        public abstract float StepDelta { get; }
        
        public float Value { get; set; }



        public virtual void Step(Character character)
        {
            Value += Math.Min(1, StepDelta);
            Satisfy(character);
        }

        public abstract void Satisfy(Character character);
    }
}
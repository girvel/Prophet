using System;

namespace Prophet.Core.Behaviour
{
    public abstract class Need
    {
        public string Name { get; set; }
        
        public float Value { get; set; }
        
        public float StepDelta { get; set; }



        public virtual void Step(Character character)
        {
            Value += Math.Min(1, StepDelta);
            Satisfy(character);
        }

        public abstract void Satisfy(Character character);
    }
}
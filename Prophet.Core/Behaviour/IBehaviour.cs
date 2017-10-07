using System;

namespace Prophet.Core.Behaviour
{
    public interface IBehaviour : ICloneable
    {
        void Step(Character character);
    }
}
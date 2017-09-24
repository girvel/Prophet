using System;

namespace Prophet.Core
{
    public interface IBehaviour : ICloneable
    {
        void Step(Character character);
    }
}
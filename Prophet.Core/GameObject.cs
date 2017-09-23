using System;

namespace Prophet.Core
{
    public abstract class GameObject
    {
        public string Name { get; set; }
        
        public ColoredCharacter Appearance { get; set; }
    }
}
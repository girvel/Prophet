using System;

namespace Prophet.Core
{
    public struct ColoredCharacter
    {
        public readonly char Character;

        public readonly ConsoleColor Foreground, Background;

        public readonly bool Transparent;
        
        

        public ColoredCharacter(
            char character, ConsoleColor foreground, 
            bool transparent = false, 
            ConsoleColor background = ConsoleColor.Black)
        {
            Character = character;
            Foreground = foreground;
            Transparent = transparent;
            Background = background;
        }

        public override string ToString() 
            => $"{typeof(ColoredCharacter).Name}({Character}, {Foreground}, {Background})";
    }
}
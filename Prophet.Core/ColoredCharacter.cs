using System;

namespace Prophet.Core
{
    public struct ColoredCharacter
    {
        public readonly char Character;

        public readonly ConsoleColor Foreground, Background;
        
        

        public ColoredCharacter(char character, ConsoleColor foreground, ConsoleColor background = ConsoleColor.Black)
        {
            Character = character;
            Foreground = foreground;
            Background = background;
        }

        public override string ToString() 
            => $"{typeof(ColoredCharacter).Name}({Character}, {Foreground}, {Background})";
    }
}
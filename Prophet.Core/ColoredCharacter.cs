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
        
        
        #region Equality
        
        public bool Equals(ColoredCharacter other)
        {
            return Character == other.Character && Foreground == other.Foreground && Background == other.Background && Transparent == other.Transparent;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ColoredCharacter && Equals((ColoredCharacter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Character.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Foreground;
                hashCode = (hashCode * 397) ^ (int) Background;
                hashCode = (hashCode * 397) ^ Transparent.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(ColoredCharacter left, ColoredCharacter right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ColoredCharacter left, ColoredCharacter right)
        {
            return !left.Equals(right);
        }
        
        #endregion
    }
}
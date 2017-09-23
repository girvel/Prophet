using System;

namespace Prophet.Core
{
    public class Scene
    {
        public virtual Decoration[,,] Decorations { get; set; }

        private Character[,,] _characters;



        public virtual void InitializeLandscape(Vector3 size)
        {
            Decorations = new Decoration[size.X, size.Y, size.Z];
            _characters = new Character [size.X, size.Y, size.Z];
        }
        
        
        
        public virtual void AddCharacter(Character character)
        {
            var currentCharacterAtPosition = GetCharacterAt(character.Position);
            if (currentCharacterAtPosition != null)
            {
                throw new ArgumentException(
                    currentCharacterAtPosition == character
                        ? "This character has been already added to this scene"
                        : "There is already another one character at character's position");
            }
            
            setCharacterAt(character.Position, character);
            character.Scene = this;
        }

        public virtual Character GetCharacterAt(Vector3 position) => _characters[position.X, position.Y, position.Z];

        private void setCharacterAt(Vector3 position, Character value) =>
            _characters[position.X, position.Y, position.Z] = value;
    }
}
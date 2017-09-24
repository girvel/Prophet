using System;
using System.Linq;
using Prophet.Core.Vector;

namespace Prophet.Core
{
    public class Scene
    {
        public virtual Decoration[,,] Decorations { get; set; }

        private Character[,,] _characters;


        #region Landscape
        
        public virtual void InitializeLandscape(Vector3 size)
        {
            Decorations = new Decoration[size.X, size.Y, size.Z];
            _characters = new Character [size.X, size.Y, size.Z];
        }

        public virtual bool IsPlaceFree(Vector3 position)
        {
            return position.X < _characters.GetLength(0)
                   && position.Y < _characters.GetLength(1)
                   && GetCharacterAt(position) == null;
        }
        
        #endregion
        
        
        #region Characters
        
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
            
            SetCharacterAt(character.Position, character);
            character.Scene = this;
        }

        public virtual Character GetCharacterAt(Vector3 position) 
            => _characters[position.X, position.Y, position.Z];

        private void SetCharacterAt(Vector3 position, Character value) 
            => _characters[position.X, position.Y, position.Z] = value;

        public virtual bool TryMoveCharacter(Character character, Vector3 to)
        {
            if (!IsPlaceFree(to))
            {
                return false;
            }
            
            SetCharacterAt(character.Position, null);
            SetCharacterAt(to, character);

            return true;
        }
        
        #endregion
        
        
        #region Behaviour

        public virtual void Step()
        {
            foreach (var character in _characters.OfType<Character>())
            {
                character.Step();
            }
        }
        
        #endregion
    }
}
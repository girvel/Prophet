using System;
using Moq;
using NUnit.Framework;
using Prophet.Core.Vector;

namespace Prophet.Core.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void Step_CallsStepOfBehaviour()
        {
            // arrange
            var behaviourMock = new Mock<IBehaviour>();
            var character = new Character {Behaviour = behaviourMock.Object};
            
            // act
            character.Step();
            
            // assert
            behaviourMock.Verify(b => b.Step(character), Times.Once);
        }
        
        [Test]
        public void TryMove_ReturnsFalseWhenThereIsNoPlace()
        {
            // arrange
            var character = new Character();
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(1, 1, 1));
            scene.AddCharacter(character);
            
            // act
            var result = character.TryMove(new Vector3(1, 2, 3));
            
            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TryMove_ReturnsTrueAndMovesCharacterWhenItIsPossible()
        {
            // arrange
            var character = new Character();
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(4, 4, 4));
            scene.AddCharacter(character);
            
            // act
            var result = character.TryMove(new Vector3(1, 2, 3));
            
            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(character, scene.GetCharacterAt(new Vector3(1, 2, 3)));
        }
    }
}
using System;
using Moq;
using NUnit.Framework;
using Prophet.Core.Vector;

namespace Prophet.Core.Tests
{
    [TestFixture]
    public class SceneTests
    {
        [Test]
        public void InitializeLandscape_CreatesEmptyDecorationArray()
        {
            // arrange
            var scene = new Scene();
            
            // act
            scene.InitializeLandscape(new Vector3(3, 3, 2));
            
            // assert
            Assert.AreEqual(3, scene.Decorations.GetLength(0));
            Assert.AreEqual(3, scene.Decorations.GetLength(1));
            Assert.AreEqual(2, scene.Decorations.GetLength(2));
        }
        
        [Test]
        public void AddCharacter_PutsCharacterOnTheSceneByItsPosition()
        {
            // arrange
            var character = Mock.Of<Character>();
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(1, 1, 1));
            
            // act
            scene.AddCharacter(character);
            
            // assert
            Assert.AreEqual(character, scene.GetCharacterAt(new Vector3()));
            Assert.AreEqual(scene, character.Scene);
        }
        
        [Test]
        public void AddCharacter_ThrowsArgumentExceptionIfThereIsNoPlaceForCharacter()
        {
            // arrange
            var character = Mock.Of<Character>();
            var character2 = Mock.Of<Character>();
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(1, 1, 1));
            scene.AddCharacter(character);
            
            // act
            
            // assert
            Assert.Throws<ArgumentException>(() => scene.AddCharacter(character2));
        }

        [Test]
        public void IsPlaceFree_ReturnsTrueIfPlaceIsFree()
        {
            // arrange
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(1, 1, 1));
            
            // act
            var result = scene.IsPlaceFree(new Vector3());
            
            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPlaceFree_ReturnsFalseIfThereIsCharacter()
        {
            // arrange
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(1, 1, 1));
            scene.AddCharacter(new Character());
            
            // act
            var result = scene.IsPlaceFree(new Vector3());
            
            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPlaceFree_ReturnsFalseIfPlaceIsOutsideSceneBorder()
        {
            // arrange
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(1, 1, 1));
            
            // act
            var result = scene.IsPlaceFree(new Vector3(1, 0, 0));
            
            // assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void TryMoveCharacter_ReturnsFalseWhenThereIsNoPlace()
        {
            // arrange
            var character = new Character();
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(1, 1, 1));
            scene.AddCharacter(character);
            
            // act
            var result = scene.TryMoveCharacter(character, new Vector3(1, 2, 3));
            
            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TryMoveCharacter_ReturnsTrueAndMovesCharacterWhenItIsPossible()
        {
            // arrange
            var character = new Character();
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(4, 4, 4));
            scene.AddCharacter(character);
            
            // act
            var result = scene.TryMoveCharacter(character, new Vector3(1, 2, 3));
            
            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(character, scene.GetCharacterAt(new Vector3(1, 2, 3)));
        }

        [Test]
        public void Step_CallsCharactersStep()
        {
            // arrange
            var scene = new Scene();
            scene.InitializeLandscape(new Vector3(3, 1, 1));
            
            var characters = new[]
            {
                new Mock<Character>(),
                new Mock<Character>(),
                new Mock<Character>(),
            };

            var i = 0;
            foreach (var character in characters)
            {
                character.SetupGet(c => c.Position).Returns(new Vector3(i++, 0, 0));
                scene.AddCharacter(character.Object);
            }
            
            // act
            scene.Step();
            
            // assert
            foreach (var character in characters)
            {
                character.Verify(c => c.Step(), Times.Once);
            }
        }
    }
}
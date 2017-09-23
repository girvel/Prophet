using System;
using Moq;
using NUnit.Framework;

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
    }
}
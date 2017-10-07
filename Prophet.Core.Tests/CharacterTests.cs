using System;
using Moq;
using NUnit.Framework;
using Prophet.Core.Behaviour;
using Prophet.Core.Vector;

namespace Prophet.Core.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void CreateByPrototype_ClonesBehaviour()
        {
            // arrange
            var prototype = new Character{Behaviour = Mock.Of<IBehaviour>(b => b.Clone() == Mock.Of<IBehaviour>())};
            
            // act
            var result = Character.CreateByPrototype(prototype);
            
            // assert
            Assert.AreNotEqual(prototype.Behaviour, result.Behaviour);
        }

        [Test]
        public void CreateByPrototype_ThrowsInvalidOperationExceptionIfSceneIsNotNull()
        {
            // arrange
            var prototype = new Character
            {
                Behaviour = Mock.Of<IBehaviour>(b => b.Clone() == Mock.Of<IBehaviour>()),
                Scene = Mock.Of<Scene>(),
            };
            
            // act
            
            // assert
            Assert.Throws<InvalidOperationException>(() => Character.CreateByPrototype(prototype));
        }
        
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
        public void Step_DoesNotCallStepOfBehaviourIfCharacterIsDead()
        {
            // arrange
            var behaviourMock = new Mock<IBehaviour>();
            var character = new Character {Behaviour = behaviourMock.Object, Health = 0};
            
            // act
            character.Step();
            
            // assert
            behaviourMock.Verify(b => b.Step(character), Times.Never);
        }
        
        [Test]
        public void TryMove_ReturnsFalseIfThereIsNoPlace()
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
        public void TryMove_ReturnsTrueAndMovesCharacterIfItIsPossible()
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

        [Test]
        public void TryAttack_ReturnsFalseIfDistanceIsTooBig()
        {
            // arrange
            var enemy = new Character{Position = new Vector3(2, 2, 0)};
            var character = new Character();
            
            // act
            var result = character.TryAttack(enemy);
            
            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TryAttack_ReturnsFalseIfEnemyIsDead()
        {
            // arrange
            var enemy = new Character{Health = 0, Position = new Vector3(1, 1, 0)};
            var character = new Character();
            
            // act
            var result = character.TryAttack(enemy);
            
            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TryAttack_ReturnsTrueAndDecreasesTargetsHealth()
        {
            // arrange
            var enemy = new Character {Health = 100, Position = new Vector3(1, 1, 1),};
            var character = new Character
            {
                Damage = 10,
            };
            
            // act
            var result = character.TryAttack(enemy);
            
            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(90, enemy.Health);
        }

        [Test]
        public void TryAttack_ReplacesAppearanceOfTheKilledCharacterAndSetsZeroHealth()
        {
            // arrange
            var enemy = new Character {Health = 100, Position = new Vector3(1, 1, 1),};
            var character = new Character
            {
                Damage = 110,
            };
            
            // act
            var result = character.TryAttack(enemy);
            
            // assert
            Assert.IsTrue(result);
            Assert.IsFalse(enemy.IsAlive);
            Assert.AreEqual(enemy.DeadBodyAppearance, enemy.Appearance);
            Assert.AreEqual(0, enemy.Health);
        }
    }
}
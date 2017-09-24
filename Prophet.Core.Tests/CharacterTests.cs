using System;
using Moq;
using NUnit.Framework;

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
    }
}
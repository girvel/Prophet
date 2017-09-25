using Moq;
using NUnit.Framework;
using Prophet.Core.Extensions;
using Prophet.Core.Vector;

namespace Prophet.Core.Tests.Extensions
{
    [TestFixture]
    public class SceneHelperTests
    {
        [Test]
        public void FindNearestCharacter_ReturnsNullIfRequestedCharacterDoesNotExist()
        {
            // arrange
            var scene = Mock.Of<Scene>(s => s.GetCharacterAt(It.IsAny<Vector3>()) == null);
            
            // act
            var result = scene.FindNearestCharacter(new Vector3(), 2, c => true);
            
            // assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void FindNearestCharacter_ReturnsNearestCharacter()
        {
            // arrange
            var characters = new[]
            {
                Mock.Of<Character>(),
                Mock.Of<Character>(),
            };
            
            var scene = new Mock<Scene>();

            scene.SetupGet(s => s.Decorations).Returns(new Decoration[5, 5, 1]);
            
            scene
                .Setup(s => s.GetCharacterAt(It.IsAny<Vector3>()))
                .Returns((Vector3 position) =>
                    position == new Vector3(1, 1, 0)
                        ? characters[0]
                        : position == new Vector3(2, 2, 0)
                            ? characters[1]
                            : null);
            
            // act
            var result = scene.Object.FindNearestCharacter(new Vector3(), 2, c => true);
            
            // assert
            Assert.AreEqual(characters[0], result);
        }
    }
}
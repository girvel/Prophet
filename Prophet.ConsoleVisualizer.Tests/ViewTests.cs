using System;
using Moq;
using NUnit.Framework;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer.Tests
{
    [TestFixture]
    public class ViewTests
    {
        [Test]
        public void GetCurrentView_ReturnsCurrentView()
        {
            // arrange
            
            #region Appearance
            
            var decoration = Mock.Of<Decoration>();
            decoration.Appearance = new ColoredCharacter('d', ConsoleColor.Blue);

            var character = Mock.Of<Character>();
            character.Appearance = new ColoredCharacter('c', ConsoleColor.Cyan);
            
            #endregion

            var scene = new Mock<Scene>();
            scene
                .Setup(s => s.GetCharacterAt(It.IsAny<Vector3>()))
                .Returns((Vector3 position) => (position == new Vector3(2, 2, 0)) ? character : null);

            scene
                .SetupGet(s => s.Decorations)
                .Returns(new[,,]
                {
                    {{decoration}, {decoration}, {decoration}},
                    {{decoration}, {decoration}, {decoration}},
                    {{decoration}, {decoration}, {decoration}},
                });
            
            var view = new View
            {
                Position = new Vector2(2, 1), 
                Size = new Vector2(1, 2),
                Height = 0,
                Scene = scene.Object,
                Filler = new ColoredCharacter(' ', ConsoleColor.Black),
            };
            
            
            // act
            
            var result = view.GetCurrentView();
            
            
            // assert

            var expectedResult = new[,]
            {
                {decoration.Appearance, character.Appearance},
            };
            
            for (var x = 0; x < result.GetLength(0); x++)
            for (var y = 0; y < result.GetLength(1); y++)
            {
                Assert.AreEqual(expectedResult[x, y], result[x, y]);
            }
        }
    }
}
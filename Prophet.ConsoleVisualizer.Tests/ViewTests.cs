using System;
using Moq;
using NUnit.Framework;
using Prophet.Core;

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
            
            var filler = new ColoredCharacter(' ', ConsoleColor.Black);
            
            var decoration = Mock.Of<Decoration>();
            decoration.Appearance = new ColoredCharacter('d', ConsoleColor.Blue);

            var character = Mock.Of<Character>();
            character.Appearance = new ColoredCharacter('c', ConsoleColor.Cyan);
            
            #endregion

            var scene = Mock.Of<Scene>();
            scene.Characters = new[,,]
            {
                {{character}, {null}, {null}},
                {{null},      {null}, {null}},
                {{character}, {null}, {character}},
            };

            scene.Decorations = new[,,]
            {
                {{decoration}, {decoration}, {decoration}},
                {{decoration}, {decoration}, {decoration}},
                {{decoration}, {decoration}, {decoration}},
            };
            
            var view = new View
            {
                Position = new Vector(2, 1), 
                Size = new Vector(1, 2),
                Height = 0,
            };
            
            
            // act
            
            var result = view.GetCurrentView(scene, filler);
            
            
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
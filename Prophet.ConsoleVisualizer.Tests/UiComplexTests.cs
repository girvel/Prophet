using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.ConsoleVisualizer.Interface.Elements;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer.Tests
{
    [TestFixture]
    public class UiComplexTests
    {
        [Test]
        public void GetCurrentView_CreatesViewByDisplayingQueue()
        {
            // arrange
            var views = new[]
            {
                new[,]
                {
                    {
                        new ColoredCharacter('q', ConsoleColor.Red),
                        new ColoredCharacter('q', ConsoleColor.Red),
                        new ColoredCharacter('q', ConsoleColor.Red),
                    }
                },
                
                new[,]
                {
                    {
                        new ColoredCharacter('q', ConsoleColor.Green),
                        new ColoredCharacter('q', ConsoleColor.Blue, true)
                    }
                },
                
                new[,]
                {
                    {
                        new ColoredCharacter('q', ConsoleColor.Blue),
                    }
                },
            };

            var complex = new UiComplex
            {
                Background = Mock.Of<IPositionedUiElement>(e => e.GetCurrentView() == views[0] && e.Position == new Vector2(0, 0)),
                DisplayingQueue = new List<IPositionedUiElement>
                {
                    Mock.Of<IPositionedUiElement>(e => e.GetCurrentView() == views[1] && e.Position == new Vector2(0, 1)),
                    Mock.Of<IPositionedUiElement>(e => e.GetCurrentView() == views[2] && e.Position == new Vector2(0, 2)),
                },
            };
            
            // act
            var result = complex.GetCurrentView();
            
            // assert
            var expectedResult = new[,]
            {
                {
                    new ColoredCharacter('q', ConsoleColor.Red),
                    new ColoredCharacter('q', ConsoleColor.Green),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                }
            };
            
            for (var x = 0; x < expectedResult.GetLength(0); x++)
            for (var y = 0; y < expectedResult.GetLength(1); y++)
            {
                Assert.AreEqual(expectedResult[x, y], result[x, y]);
            }
        }
    }
}
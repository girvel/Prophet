using System;
using NUnit.Framework;
using Prophet.Core;
using Prophet.Core.Vector;

namespace Prophet.ConsoleVisualizer.Tests
{
    [TestFixture]
    public class ViewingHelperTests
    {
        [Test]
        public void Put_PutsForegroundOverBackground()
        {
            // arrange
            var background = new[,]
            {
                {
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                }
            };
            
            var foreground = new[,]
            {
                {
                    new ColoredCharacter('w', ConsoleColor.Blue),
                    new ColoredCharacter('w', ConsoleColor.Blue, transparent: true),
                    new ColoredCharacter('w', ConsoleColor.Blue),
                }
            };
            
            // act
            background.Put(foreground, new Vector2(0, 1));
            
            // assert
            var expectedResult = new[,]
            {
                {
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('w', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('w', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                }
            };
            
            for (var x = 0; x < expectedResult.GetLength(0); x++)
            for (var y = 0; y < expectedResult.GetLength(1); y++)
            {
                Assert.AreEqual(expectedResult[x, y], background[x, y]);
            }
        }

        [Test]
        public void Put_ThrowsArgumentExceptionWhenForegroundCanNotBePlacedOnThisBackground()
        {
            // arrange
            var background = new[,]
            {
                {
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                    new ColoredCharacter('q', ConsoleColor.Blue),
                }
            };
            
            var foreground = new[,]
            {
                {
                    new ColoredCharacter('w', ConsoleColor.Blue),
                    new ColoredCharacter('w', ConsoleColor.Blue, transparent: true),
                    new ColoredCharacter('w', ConsoleColor.Blue),
                }
            };
            
            // act
            
            // assert
            Assert.Throws<ArgumentException>(() => background.Put(foreground, new Vector2(0, 3)));
        }
    }
}
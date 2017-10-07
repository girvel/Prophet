using System;
using Moq;
using NUnit.Framework;
using Prophet.ConsoleVisualizer.Interface;
using Prophet.ConsoleVisualizer.Interface.Elements;
using Prophet.Core;

namespace Prophet.ConsoleVisualizer.Tests.Interface
{
    [TestFixture]
    public class IndicatorTests
    {
        private class TestIndicator : Indicator
        {
            protected override string[] GetContent() => new[] {"Hello", "world!"};
        }
        
        [Test]
        public void GetCurrentView_ReturnsArrayOfGrayCharactersMadeOfStringArray()
        {
            // arrange
            var indicator = new TestIndicator();
            
            // act
            var result = indicator.GetCurrentView();
            
            // assert
            var expectedResult = new[,]
            {
                {
                    new ColoredCharacter('H', ConsoleColor.Gray),
                    new ColoredCharacter('w', ConsoleColor.Gray),
                },
                {
                    new ColoredCharacter('e', ConsoleColor.Gray),
                    new ColoredCharacter('o', ConsoleColor.Gray),
                },
                {
                    new ColoredCharacter('l', ConsoleColor.Gray),
                    new ColoredCharacter('r', ConsoleColor.Gray),
                },
                {
                    new ColoredCharacter('l', ConsoleColor.Gray),
                    new ColoredCharacter('l', ConsoleColor.Gray),
                },
                {
                    new ColoredCharacter('o', ConsoleColor.Gray),
                    new ColoredCharacter('d', ConsoleColor.Gray),
                },
                {
                    default(ColoredCharacter),
                    new ColoredCharacter('!', ConsoleColor.Gray),
                },
            };
            
            for (var x = 0; x < expectedResult.GetLength(0); x++)
            for (var y = 0; y < expectedResult.GetLength(1); y++)
            {
                Assert.AreEqual(expectedResult[x, y], result[x, y]);
            }
        }
    }
}
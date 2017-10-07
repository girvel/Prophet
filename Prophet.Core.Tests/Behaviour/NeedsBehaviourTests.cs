using Moq;
using NUnit.Framework;
using Prophet.Core.Behaviour;

namespace Prophet.Core.Tests.Behaviour
{
    [TestFixture]
    public class NeedsBehaviourTests
    {
        [Test]
        public void Step_CallsStepOfTheBiggestNeed()
        {
            // arrange
            var needMock1 = new Mock<Need>();
            needMock1.Object.Value = 1;
            
            var needMock2 = new Mock<Need>();
            needMock2.Object.Value = 0.5f;
            
            var behaviour = new NeedsBehaviour
            {
                Needs = new[]
                {
                    needMock1.Object,
                    needMock2.Object,
                },
            };

            // act
            behaviour.Step(null);

            // assert
            needMock1.Verify(m => m.Step(null), Times.Once);
        }
    }
}
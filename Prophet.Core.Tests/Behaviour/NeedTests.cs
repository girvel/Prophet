using NUnit.Framework;
using Prophet.Core.Behaviour;

namespace Prophet.Core.Tests.Behaviour
{
    [TestFixture]
    public class NeedTests
    {
        [Test]
        public void Step_IncreasesValueByDelta()
        {
            // arrange
            var need = new NeedRealization{Value = 0};
            
            // act
            need.Step(null);
            
            // assert
            Assert.AreEqual(0.5f, need.Value);
        }
        
        [Test]
        public void Step_CallsSatisfy()
        {
            // arrange
            var need = new NeedRealization();
            
            // act
            need.Step(null);
            
            // assert
            Assert.IsTrue(need.WasSatisfyCalled);
        }
        
        
        
        private class NeedRealization : Need
        {
            public bool WasSatisfyCalled = false;

            public override string Name => "";
        
            public override float StepDelta => 0.5f;

            public override void Satisfy(Character character)
            {
                WasSatisfyCalled = true;
            }
        }
    }
}
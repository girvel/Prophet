using System.Linq;

namespace Prophet.Core.Behaviour
{
    public class NeedsBehaviour : IBehaviour
    {
        public Need[] Needs { get; set; }
        
        
        
        public object Clone() => MemberwiseClone();

        public void Step(Character character)
        {
            Needs.OrderBy(n => 1 - n.Value).First().Step(character);
        }
    }
}
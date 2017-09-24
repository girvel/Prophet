using Prophet.Core.Vector;

namespace Prophet.Core
{
    public class Character : GameObject
    {
        public virtual Vector3 Position { get; private set; }
        
        public Scene Scene { get; set; }
        
        public IBehaviour Behaviour { get; set; }



        public virtual void Step()
        {
            Behaviour.Step(this);
        }

        public virtual bool TryMove(Vector3 to)
        {
            if (Scene.TryMoveCharacter(this, to))
            {
                Position = to;
                return true;
            }
            
            return false;
        }
    }
}
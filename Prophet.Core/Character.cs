namespace Prophet.Core
{
    public class Character : GameObject
    {
        public Vector3 Position { get; }
        
        public Scene Scene { get; internal set; }
    }
}
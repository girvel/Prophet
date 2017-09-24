namespace Prophet.Core.Vector
{
    public struct Vector2
    {
        public readonly int X, Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }


        public static bool operator ==(Vector2 v1, Vector2 v2) => v1.Equals(v2);

        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1 == v2);
    }
}
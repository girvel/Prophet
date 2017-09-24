namespace Prophet.Core.Vector
{
    public struct Vector3
    {
        public readonly int X, Y, Z;

        public Vector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public static bool operator ==(Vector3 v1, Vector3 v2) => v1.Equals(v2);

        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1 == v2);
    }
}
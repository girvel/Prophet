using System;
using System.Security.Cryptography;

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


        #region Equality
        
        public bool Equals(Vector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector3 && Equals((Vector3) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                return hashCode;
            }
        }
        
        #endregion

        
        #region Operators
        
        public static bool operator ==(Vector3 v1, Vector3 v2) => v1.Equals(v2);

        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1 == v2);
        
        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => v1 + -v2;
        
        public static Vector3 operator -(Vector3 v) => new Vector3(-v.X, -v.Y, -v.Z);
        
        #endregion
    }
}
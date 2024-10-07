using System;
using Math.Utilities;

namespace Math.Vectors;

public struct Vector3 : IEquatable<Vector3> {
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    
    public Vector3(float x, float y, float z) => (X, Y, Z) = (x, y, z);

    public float Length => MathF.Sqrt(X * X + Y * Y + Z * Z);
    public float LengthSquared => X * X + Y * Y + Z * Z;

    public Vector3 Normalized {
        get {
            var len = Length;

            return len > 0 ? new Vector3(X / len, Y / len, Z / len) : this;
        }
    }

    public static Vector3 operator +(Vector3 left, Vector3 right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    public static Vector3 operator -(Vector3 left, Vector3 right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    public static Vector3 operator *(Vector3 vector, float scalar) => new(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
    public static Vector3 operator /(Vector3 vector, float scalar) => new(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);

    public static float Dot(Vector3 left, Vector3 right) => left.X * right.X + left.Y * right.Y + left.Z * right.Z;
    public static Vector3 Cross(Vector3 left, Vector3 right) {
        return new Vector3(
            left.Y * right.Z - left.Z * right.Y,
            left.Z * right.X - left.X * right.Z,
            left.X * right.Y - left.Y * right.X
        );
    }
    
    public bool Equals(Vector3 other) => MathF.Abs(X - other.X) < Constants.Epsilon && MathF.Abs(Y - other.Y) < Constants.Epsilon && MathF.Abs(Z - other.Z) < Constants.Epsilon;
    public override bool Equals(object? obj) => obj is Vector3 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    public override string ToString() => $"Vector3({X}, {Y}, {Z})";
}
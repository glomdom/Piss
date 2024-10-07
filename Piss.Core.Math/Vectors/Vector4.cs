using System;
using Math.Utilities;

namespace Math.Vectors;

public struct Vector4 : IEquatable<Vector4> {
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float W { get; set; }

    public Vector4(float x, float y, float z, float w) => (X, Y, Z, W) = (x, y, z, w);

    public float Length => MathF.Sqrt(X * X + Y * Y + Z * Z + W * W);
    public float LengthSquared => X * X + Y * Y + Z * Z + W * W;

    public Vector4 Normalized {
        get {
            var len = Length;

            return len > 0 ? new Vector4(X / len, Y / len, Z / len, W / len) : this;
        }
    }

    public static Vector4 operator +(Vector4 left, Vector4 right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
    public static Vector4 operator -(Vector4 left, Vector4 right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
    public static Vector4 operator *(Vector4 vector, float scalar) => new(vector.X * scalar, vector.Y * scalar, vector.Z * scalar, vector.W * scalar);
    public static Vector4 operator /(Vector4 vector, float scalar) => new(vector.X / scalar, vector.Y / scalar, vector.Z / scalar, vector.W / scalar);

    public static float Dot(Vector4 left, Vector4 right) => left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;

    public bool Equals(Vector4 other) => MathF.Abs(X - other.X) < Constants.Epsilon && MathF.Abs(Y - other.Y) < Constants.Epsilon && MathF.Abs(Z - other.Z) < Constants.Epsilon && MathF.Abs(W - other.W) < Constants.Epsilon;
    public override bool Equals(object? obj) => obj is Vector4 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

    public override string ToString() => $"Vector4({X}, {Y}, {Z}, {W})";
}
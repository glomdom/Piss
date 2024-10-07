using Math.Utilities;

namespace Math.Vectors;

public struct Vector2 : IEquatable<Vector2> {
    public float X { get; set; }
    public float Y { get; set; }

    public Vector2(float x, float y) => (X, Y) = (x, y);

    public float Length => MathF.Sqrt(X * X + Y * Y);
    public float LengthSquared => X * X + Y * Y;

    public Vector2 Normalized {
        get {
            var len = Length;

            return len == 0 ? this : new Vector2(X / len, Y / len);
        }
    }
    
    public static readonly Vector2 Zero = new(0f, 0f);
    
    public static Vector2 operator +(Vector2 left, Vector2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Vector2 operator -(Vector2 left, Vector2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Vector2 operator *(Vector2 vector, float scalar) => new(vector.X * scalar, vector.Y * scalar);
    public static Vector2 operator /(Vector2 vector, float scalar) => new(vector.X / scalar, vector.Y / scalar);
    
    public static float Dot(Vector2 left, Vector2 right) => left.X * right.X + left.Y * right.Y;
    public static float Cross(Vector2 left, Vector2 right) => left.X * right.Y - left.Y * right.X;

    public static Vector2 Min(Vector2 a, Vector2 b) => new(MathF.Min(a.X, b.X), MathF.Min(a.Y, b.Y));
    public static Vector2 Max(Vector2 a, Vector2 b) => new(MathF.Max(a.X, b.X), MathF.Max(a.Y, b.Y));

    public static float Distance(Vector2 a, Vector2 b) => (a - b).Length;
    
    public bool Equals(Vector2 other) => System.Math.Abs(X - other.X) < Constants.Epsilon && System.Math.Abs(Y - other.Y) < Constants.Epsilon;
    public override bool Equals(object? obj) => obj is Vector2 other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y);

    public void Deconstruct(out float x, out float y) => (x, y) = (X, Y);
    
    public override string ToString() => $"Vector2({X}, {Y})";
}
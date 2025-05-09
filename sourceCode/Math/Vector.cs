

public struct Vector(float x, float y)
{
    private float _x = x;
    private float _y = y;

    public void Add(float x, float y) {
        _x += x;
        _y += y;
    }
    public void Add(Vector vector) {
        _x += vector.X;
        _y += vector.Y;
    }
    public float X {
        readonly get {return _x; }
        set { _x = value; }
    }
    public float Y {
        readonly get {return _y; }
        set { _y = value; }
    }

}
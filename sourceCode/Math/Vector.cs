

public struct Vector {
    private float _x = 0;
    private float _y = 0;

    public Vector(float x, float y) {
        _x = x;
        _y = y;
    }
    public Vector() {

    }
    public void Add(float x, float y) {
        _x += x;
        _y += y;
    }
    public void Add(Vector vector) {
        _x += vector.X;
        _y += vector.Y;
    }
    public float X {
        get {return _x; }
        set { _x = value; }
    }
    public float Y {
        get {return _y; }
        set { _y = value; }
    }

}
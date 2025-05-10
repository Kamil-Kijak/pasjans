public class SelectPanel2d {
    private readonly IPanel[,] _objects;
    private readonly ConsoleColor _changeColor;
    private readonly ConsoleColor[,] _previrousColors;
    private Vector _index;
    public enum ChooseState {
        CHOOSEN = 0,
        CHANGED = 1,
        STILL = 2
    }
    public SelectPanel2d(IPanel[,] objects, ConsoleColor changeColor, Vector startingIndex) {
        _index = startingIndex;
        _objects = objects;
        _previrousColors = new ConsoleColor[objects.GetLength(0), objects.GetLength(1)];
        SetPrevirousColors();
        _changeColor = changeColor;
    }
    private void SetPrevirousColors() {
        for (int i = 0; i < _objects.GetLength(0); i++){
            for (int j = 0; j < _objects.GetLength(1); j++) {
                _previrousColors[i, j] = _objects[i, j].ForegroundColor;
            }
        }
    }
    public void Draw(Vector position, bool drawSelection, int[,] widthMargin, int hightMargin = 0, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP) {
        Vector separator = new();
        SetPrevirousColors();
        for (int i = 0; i < _objects.GetLength(0); i++) {
            for(int j = 0;j<_objects.GetLength(1);j++) {
                if(i == _index.Y && j == _index.X && drawSelection) {
                    _objects[i, j].ForegroundColor = _changeColor;
                    _objects[i, j].Draw(new Vector(position.X + separator.X, position.Y + separator.Y), alignX, alignY);
                    _objects[i, j].ForegroundColor = _previrousColors[i, j];
                } else {
                    _objects[i, j].Draw(new Vector(position.X + separator.X, position.Y + separator.Y), alignX, alignY);
                }
                separator.X+= _objects[i, j].Width;
                if(_objects.GetLength(1) - 1 != j) {
                    separator.X+=widthMargin[i, j];
                }
            }
            separator.Y+= _objects[i, 0].Height + hightMargin;
            separator.X = 0;
        }
    }
    public ChooseState Listen() {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch(key.Key) {
            case ConsoleKey.Enter:
            return ChooseState.CHOOSEN;
            case ConsoleKey.W:
                _index.Add(0, -1);
                if(_index.Y < 0) {
                    _index.Y = _objects.GetLength(0) - 1;
                }
            return ChooseState.CHANGED;
            case ConsoleKey.S:
                _index.Add(0, 1);
                if(_index.Y > _objects.GetLength(0) - 1) {
                    _index.Y = 0;
                }
            return ChooseState.CHANGED;
            case ConsoleKey.A:
                _index.Add(-1, 0);
                if(_index.X < 0) {
                    _index.X = _objects.GetLength(1) - 1;
                }
            return ChooseState.CHANGED;
            case ConsoleKey.D:
                _index.Add(1, 0);
                if(_index.X > _objects.GetLength(1) - 1) {
                    _index.X = 0;
                }
            return ChooseState.CHANGED;
            default:
            return ChooseState.STILL;
        }
    }
    public Vector Index {
        get { return _index; }
        set {
            _index = value;
        }
    }
}
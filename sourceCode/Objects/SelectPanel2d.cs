public class SelectPanel2d {
    private IPanel[,] _objects;
    private ConsoleColor _changeColor;
    private ConsoleColor[,] _previrousColors;
    private Vector _index;
    public SelectPanel2d(IPanel[,] objects, ConsoleColor changeColor, Vector startingIndex) {
        _index = startingIndex;
        _objects = objects;
        _previrousColors = new ConsoleColor[objects.GetLength(0), objects.GetLength(1)];
        for (int i = 0; i < objects.GetLength(0); i++){
            for (int j = 0; j < objects.GetLength(1); j++) {
                _previrousColors[i, j] = _objects[i, j].ForegroundColor;
            }
        }
        _changeColor = changeColor;
        _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _changeColor;
    }
    public enum ChooseState {
        CHOOSEN = 0,
        CHANGED = 1,
        STILL = 2
    }
    public void Draw(Vector position, int margin = 0, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP) {
        Vector separator = new Vector(0, 0);
        for (int i = 0; i < _objects.GetLength(0); i++) {
            for(int j = 0;j<_objects.GetLength(1);j++) {
                _objects[i, j].Draw(new Vector(position.X + separator.X, position.Y + separator.Y), alignX, alignY);
                separator.X+= _objects[i, j].Width + margin;
            }
            separator.Y+= _objects[i, 0].Height + margin;
            separator.X = 0;
        }
    }
    public ChooseState Listen() {
        ConsoleKeyInfo key = Console.ReadKey();
        switch(key.Key) {
            case ConsoleKey.Enter:
            return ChooseState.CHOOSEN;
            case ConsoleKey.W:
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _previrousColors[(int)_index.Y, (int)_index.X];
                _index.Add(0, -1);
                if(_index.Y < 0) {
                    _index.Y = _objects.GetLength(0) - 1;
                }
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _changeColor;
            return ChooseState.CHANGED;
            case ConsoleKey.S:
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _previrousColors[(int)_index.Y, (int)_index.X];
                _index.Add(0, 1);
                if(_index.Y > _objects.GetLength(0) - 1) {
                    _index.Y = 0;
                }
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _changeColor;
            return ChooseState.CHANGED;
            case ConsoleKey.A:
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _previrousColors[(int)_index.Y, (int)_index.X];
                _index.Add(-1, 0);
                if(_index.X < 0) {
                    _index.X = _objects.GetLength(1) - 1;
                }
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _changeColor;
            return ChooseState.CHANGED;
            case ConsoleKey.D:
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _previrousColors[(int)_index.Y, (int)_index.X];
                _index.Add(1, 0);
                if(_index.X > _objects.GetLength(1) - 1) {
                    _index.X = 0;
                }
                _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _changeColor;
            return ChooseState.CHANGED;
            default:
            return ChooseState.STILL;
        }
    }
    public Vector Index {
        get { return _index; }
        set { 
            _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _previrousColors[(int)_index.Y, (int)_index.X];
            _index = value;
            _objects[(int)_index.Y, (int)_index.X].ForegroundColor = _changeColor;
            }
    }
}
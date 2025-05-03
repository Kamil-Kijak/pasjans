

public class SelectPanel {
    private DrawableObject[] _objects;
    private ConsoleColor _changeColor;
    private ConsoleColor[] _previrousColors;
    private int _index;
    private Direction _direction;
    private ConsoleKey _upKey;
    private ConsoleKey _downKey;
    public SelectPanel(DrawableObject[] objects, ConsoleColor changeColor, int startingIndex = 0, Direction direction = Direction.VERTICALY) {
        _index = startingIndex;
        _objects = objects;
        _previrousColors = new ConsoleColor[objects.Length];
        for (int i = 0; i < objects.Length; i++){
            _previrousColors[i] = _objects[i].ForegroundColor;
        }
        _changeColor = changeColor;
        _objects[_index].ForegroundColor = _changeColor;
        _direction = direction;
        if(direction == Direction.VERTICALY) {
            _upKey = ConsoleKey.W;
            _downKey = ConsoleKey.S;
        } else {
            _upKey = ConsoleKey.A;
            _downKey = ConsoleKey.D;
        }
    }
    public enum Direction {
        VERTICALY = 0,
        HORIZONTALY = 1,
    }
    public enum ChooseState {
        CHOOSEN = 0,
        CHANGED = 1,
        STILL = 2
    }
    public void Draw(Vector position, int margin = 0, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP) {
        int separator = 0;
        for (int i = 0; i < _objects.Length; i++) {
            _objects[i].Draw(new Vector(position.X + separator * (int)_direction, position.Y + separator * Math.Abs(-1 + (int)_direction)), alignX, alignY);
            if(_direction == Direction.VERTICALY) {
                separator+= _objects[i].Height + margin;
            } else {
                separator+= _objects[i].Width + margin;
            }
        }
    }
    public ChooseState Listen() {
        ConsoleKeyInfo key = Console.ReadKey();
        if(key.Key == ConsoleKey.Enter) {
            return ChooseState.CHOOSEN;
        } else if(_upKey == key.Key) {
            _objects[_index].ForegroundColor = _previrousColors[_index];
            _index--;
            if(_index < 0) {
                _index = _objects.Length - 1;
            }
            _objects[_index].ForegroundColor = _changeColor;
            return ChooseState.CHANGED;
        } else if(_downKey == key.Key) {
             _objects[_index].ForegroundColor = _previrousColors[_index];
            _index++;
            if(_index > _objects.Length - 1) {
                _index = 0;
            }
            _objects[_index].ForegroundColor = _changeColor;
            return ChooseState.CHANGED;
        } else {
            return ChooseState.STILL;
        }
    }
    public int Index {
        get { return _index; }
        set { 
            _objects[_index].ForegroundColor = _previrousColors[_index];
            _index = value;
            _objects[_index].ForegroundColor = _changeColor;
            }
    }
}
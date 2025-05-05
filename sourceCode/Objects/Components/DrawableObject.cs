

public class DrawableObject {
    protected string[] _lines;
    protected int _width;
    protected int _height;
    protected ConsoleColor _foregroundColor;
    protected ConsoleColor _backgroundColor;
    public DrawableObject(string lines) {
        _lines = lines.Split(["\r\n", "\n"], StringSplitOptions.None);
        _width = _lines[0].Length;
        _height = _lines.Length;
        _foregroundColor = ConsoleColor.White;
        _backgroundColor = ConsoleColor.Black;
    }
    public DrawableObject(string lines, ConsoleColor foregroundColor, ConsoleColor backgroundColor) {
        _lines = lines.Split(["\r\n", "\n"], StringSplitOptions.None);
        _width = _lines[0].Length;
        _height = _lines.Length;
        _foregroundColor = foregroundColor;
        _backgroundColor = backgroundColor;
    }
    public virtual void Draw(Vector position, AlignX alignX, AlignY alignY) {
        Console.ForegroundColor = _foregroundColor;
        Console.BackgroundColor = _backgroundColor;
        int xPos = (int)Math.Ceiling(position.X - _width * ((int)alignX / 2f));
        int yPos;
        if(xPos < 0) {
            xPos = 0;
        }
        if(xPos >= Console.WindowWidth) {
            xPos = Console.WindowWidth - 1;
        }
        for (int i = 0;i<_lines.Length;i++) {
            yPos = (int)Math.Floor(position.Y + i - _height * ((int)alignY / 2f));
            if(yPos < 0) {
                yPos = 0;
            }
            if(yPos >= Console.WindowHeight) {
                yPos = Console.WindowHeight - 1;
            }
            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine(_lines[i]);
        }
        Console.ResetColor();
    }
    public virtual void Draw(Vector position) {
        Console.ForegroundColor = _foregroundColor;
        Console.BackgroundColor = _backgroundColor;
        if(position.X >= Console.WindowWidth) {
            position.X = Console.WindowWidth - 1;
        }
        for (int i = 0;i<_lines.Length;i++) {
            if(position.Y + i >= Console.WindowHeight) {
                position.Y = Console.WindowHeight - 1 - i;
            }
            Console.SetCursorPosition((int)position.X, (int)position.Y + i);
            Console.WriteLine(_lines[i]);
        }
        Console.ResetColor();
    }
    public int Width {
        get{ return _width; }
        set {_width = value;}
    }
    public int Height {
        get{ return _height; }
        set {_width = value;}
    }
    public virtual ConsoleColor ForegroundColor {
        set {
            _foregroundColor = value;
        }
        get { return _foregroundColor; }
    }
    public virtual ConsoleColor BackgroundColor {
        set {
            _backgroundColor = value;
        }
        get { return _backgroundColor; }
    }
    public string Lines {
        set {
            _lines = value.Split(["\r\n", "\n"], StringSplitOptions.None);
            _width = _lines[0].Length;
            _height = _lines.Length;
        }
        get {
            return string.Join("\n", _lines);
        }
    }
}
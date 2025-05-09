

public class DrawableObject {
    protected string[] _lines;
    protected int _width;
    protected int _height;
    protected ConsoleColor _foregroundColor;
    public DrawableObject(string lines) {
        _lines = lines.Split(["\r\n", "\n"], StringSplitOptions.None);
        _width = _lines[0].Length;
        _height = _lines.Length;
        _foregroundColor = ConsoleColor.White;
    }
    public DrawableObject(string lines, ConsoleColor foregroundColor) {
        _lines = lines.Split(["\r\n", "\n"], StringSplitOptions.None);
        _width = _lines[0].Length;
        _height = _lines.Length;
        _foregroundColor = foregroundColor;
    }
    public virtual void Draw(Vector position, AlignX alignX, AlignY alignY) {
        Console.ForegroundColor = _foregroundColor;
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
    public int Width {
        get{ return _width; }
    }
    public int Height {
        get{ return _height; }
    }
    public virtual ConsoleColor ForegroundColor {
        set {
            _foregroundColor = value;
        }
        get { return _foregroundColor; }
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
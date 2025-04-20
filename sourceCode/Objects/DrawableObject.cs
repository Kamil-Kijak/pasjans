

public class DrawableObject {
    protected string[] _lines;
    protected int _width;
    protected int _height;
    private ConsoleColor _foregroundColor;
    private ConsoleColor _backgroundColor;
    public DrawableObject(string lines) {
        _lines = lines.Split("\n");
        _width = _lines[0].Length;
        _height = _lines.Length;
        _foregroundColor = ConsoleColor.White;
        _backgroundColor = ConsoleColor.Black;
    }
    public DrawableObject(string lines, ConsoleColor foregroundColor, ConsoleColor backgroundColor) {
        _lines = lines.Split("\n");
        _width = _lines[0].Length;
        _height = _lines.Length;
        _foregroundColor = foregroundColor;
        _backgroundColor = backgroundColor;
    }
    public virtual void Draw(Vector position, AlignX alignX, AlignY alignY) {
        Console.ForegroundColor = _foregroundColor;
        Console.BackgroundColor = _backgroundColor;
        int xPos = (int)(position.X - _width * ((int)alignX / 2f));
        int yPos;
        if(xPos < 0) {
            xPos = 0;
        }
        if(xPos > Console.WindowWidth) {
            xPos = Console.WindowWidth;
        }
        for (int i = 0;i<_lines.Length;i++) {
            yPos = (int)(position.Y + i - _height * ((int)alignY / 2f));
            if(yPos < 0) {
                yPos = 0;
            }
            if(yPos > Console.WindowHeight) {
                yPos = Console.WindowHeight;
            }
            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine(_lines[i]);
        }
        Console.ResetColor();
    }
    public virtual void Draw(Vector position) {
        Console.ForegroundColor = _foregroundColor;
        Console.BackgroundColor = _backgroundColor;
        for (int i = 0;i<_lines.Length;i++) {
            Console.SetCursorPosition((int)position.X, (int)position.Y + i);
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
    public ConsoleColor ForegroundColor {
        set {
            _foregroundColor = value;
        }
    }
    public ConsoleColor BackgroundColor {
        set {
            _backgroundColor = value;
        }
    }
    public  string Lines {
        set {
            _lines = value.Split("\n");
            _width = _lines[0].Length;
            _height = _lines.Length;
        }
    }
}
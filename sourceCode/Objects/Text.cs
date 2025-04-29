
public class Text : DrawableObject {
    public Text(string[] linesOfText) : base(string.Join("\n", linesOfText)) {

    }
    public Text(string text) : base(string.Join("\n", [text])) {
        
    }

    public Text(string[] linesOfText, ConsoleColor foregroundColor, ConsoleColor backgroundColor) : base(string.Join("\n", linesOfText),foregroundColor, backgroundColor) {

    }
    public Text(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor) : base(string.Join("\n", [text]),foregroundColor, backgroundColor) {

    }
    public override void Draw(Vector position, AlignX alignX, AlignY alignY)
    {
        Console.ForegroundColor = _foregroundColor;
        Console.BackgroundColor = _backgroundColor;
        int xPos;
        int yPos;
        for (int i = 0;i<_lines.Length;i++) {
            _width = _lines[i].Length;
            yPos = (int)(position.Y + i - _height * ((int)alignY / 2f));
            xPos = (int)(position.X - _width * ((int)alignX / 2f));
            if(xPos < 0) {
                xPos = 0;
            }
            if(xPos >= Console.WindowWidth) {
                xPos = Console.WindowWidth - 1;
            }
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
    public new string[] Lines {
        set {
            _lines = value;
            _width = _lines[0].Length;
            _height = _lines.Length;
        }
    }
}
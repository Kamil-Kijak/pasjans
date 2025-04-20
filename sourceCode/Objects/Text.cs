
public class Text : DrawableObject {
    public Text(string[] linesOfText) : base(string.Join("\n", linesOfText)) {

    }
    public Text(string[] linesOfText, ConsoleColor foregroundColor, ConsoleColor backgroundColor) : base(string.Join("\n", linesOfText),foregroundColor, backgroundColor) {

    }
    public new string[] Lines {
        set {
            _lines = value;
            _width = _lines[0].Length;
            _height = _lines.Length;
        }
    }
}

public static class DrawManager {

    public static void DrawBackground(ConsoleColor backgroundColor) {
        Console.BackgroundColor = backgroundColor;
        string line = "";
        for(int i = 0;i<Console.WindowWidth;i++) {
            line += " ";
        }
        for(int i = 0;i<Console.WindowHeight;i++) {
            Console.WriteLine(line);
        }
        Console.ResetColor();
    }
    public static DrawableObject CreateBox(int width, int heigth, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black) {
        string stringObject = "";
        stringObject += '+';
        for (int i = 0; i < width - 2; i++) {
            stringObject += '-';
        }
        stringObject += '+';
        stringObject += '\n';
        for (int i = 0; i < heigth - 2; i++)
        {
            stringObject += '|';
            for (int j = 0; j < width - 2; j++) {
                stringObject += ' ';
            }
            stringObject += '|';
            stringObject += '\n';
        }
        stringObject += '+';
        for (int i = 0; i < width - 2; i++) {
            stringObject += '-';
        }
        stringObject += '+';
        stringObject += '\n';

        DrawableObject box = new (stringObject, foregroundColor, backgroundColor);
        return box;
    }
    public static Text CreateText(string[] linesOfText, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black) {
        Text text = new (linesOfText, foregroundColor, backgroundColor);
        return text;
    }
    public static void DrawComponets() {
        
    }
}
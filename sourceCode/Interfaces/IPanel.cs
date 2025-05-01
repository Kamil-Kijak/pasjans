
public interface IPanel {
    

    void Draw(Vector position);
    void Draw(Vector position, AlignX alignX, AlignY alignY);
    void ActionPerformed();
    ConsoleColor ForegroundColor {get; set;}
    ConsoleColor BackgroundColor {get; set;}
    int Width {get; set;}
    int Height {get; set;}
}
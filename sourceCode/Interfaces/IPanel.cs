
public interface IPanel {
    

    void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP);
    void ActionPerformed();
    ConsoleColor ForegroundColor {get; set;}
    ConsoleColor BackgroundColor {get; set;}
    int Width {get; set;}
    int Height {get; set;}
}
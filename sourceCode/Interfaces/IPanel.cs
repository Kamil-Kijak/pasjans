
public interface IPanel {
    

    void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP);
    void ActionPerformed();
    ConsoleColor ForegroundColor {get; set;}
    int Width {get;}
    int Height {get;}
}
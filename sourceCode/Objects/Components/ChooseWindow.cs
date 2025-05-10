
public class ChooseWindow {
    private bool _active;
    private readonly DrawableObject _box;
    private readonly Text _question;
    private readonly SelectPanel2d _selection;
    public ChooseWindow(Vector size, string question, IPanel[,] options) {
        _active = false;
        _box = ContentManager.CreateBox((int)size.X, (int)size.Y);
        _question = new(question);
        _selection = new(options, ConsoleColor.Red, new Vector(0, 0));
    }
    public void Draw(Vector position, int[,] margin, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP) {
        if(_active) {
            _box.Draw(position, alignX, alignY);
            position.Y+=2;
            _question.Draw(position, alignX, AlignY.TOP);
            position.Y += 2;
            _selection.Draw(position, true, margin, 1, alignX, AlignY.TOP);
        }
    }
    public Vector Listen() {
        if(_active) {
            if(_selection.Listen() == SelectPanel2d.ChooseState.CHOOSEN) {
                return _selection.Index;
            }
        }
        return new Vector(-1, -1);
    }
    public bool Active {
        get { return _active; }
        set{
            _active = value;
            _selection.Index = new Vector(0, 0);
            }
    }
}
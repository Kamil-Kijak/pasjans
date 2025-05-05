

public class UndoSection : IPanel
{
    private DrawableObject _box;
    private Text _undoText;
    public UndoSection() {
        _box = DrawManager.CreateBox(17, 5);
        _undoText = new("Cofnij ruch");
    }
    public void ActionPerformed()
    {
        
    }

    public void Draw(Vector position)
    {
        _box.Draw(position, AlignX.LEFT, AlignY.TOP);
    }

    public void Draw(Vector position, AlignX alignX, AlignY alignY)
    {
        position.Y+= 4;
        _box.Draw(position, alignX, alignY);
        position.X += _box.Width / 2;
        position.Y += _box.Height / 2;
        _undoText.Draw(position, AlignX.CENTER, AlignY.CENTER);
    }
    public ConsoleColor ForegroundColor {
         get {
            return _box.ForegroundColor;
         }
         set {
            _box.ForegroundColor = value;
            _undoText.ForegroundColor = value;
         }
    }
    public ConsoleColor BackgroundColor {
          get {
            return _box.BackgroundColor;
         }
         set {
            _box.BackgroundColor = value;
            _undoText.BackgroundColor = value;
         }
    }
    public int Width {
         get {
            return _box.Width;
         }
         set {
            _box.Width = value;
         }
    }
    public int Height {
        get {
            return _box.Height;
        }
        set {
            _box.Height = value;
        }
    }
}
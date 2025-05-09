


public class ExitSection : IPanel {
    private Text _text;
    public ExitSection() {
        _text = new("Wyjście");
    }

    public void ActionPerformed()
    {
        ContentManager.GetScene(Scenes.GAME_SCENE).SceneActive = false;
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        position.Y+= 5;
        _text.Draw(position, alignX, alignY);
    }
    public ConsoleColor ForegroundColor {
        get {return _text.ForegroundColor;}
        set {_text.ForegroundColor = value;}
    }
    public int Width {
        get {return _text.Width;}
    }
    public int Height {
         get {return _text.Height;}
    }
}
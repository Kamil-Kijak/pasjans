


public class ExitSection : IPanel {
    private Text _text;
    public ExitSection() {
        _text = new("Wyjście");
    }

    public void ActionPerformed()
    {

        Content.GetScene(Scenes.GAME_SCENE).SceneActive = false;
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
    public ConsoleColor BackgroundColor {
        get {return _text.BackgroundColor;}
        set {_text.BackgroundColor = value;}
    }
    public int Width {
        get {return _text.Width;}
        set {_text.Width = value;}
    }
    public int Height {
         get {return _text.Height;}
        set {_text.Height = value;}
    }
}
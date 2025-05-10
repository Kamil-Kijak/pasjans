


public class ExitSection : IPanel {
    private readonly Text _text;
    private readonly ChooseWindow _acceptExitWindow;
    public ExitSection() {
        _text = new("Wyjście");
        _acceptExitWindow = new(new Vector(40, 10), "Napewno chcesz wyjść?",
        new IPanel[,]{{new Text("--->Tak<---")}, {new Text("--->Nie<---")}});
    }

    public void ActionPerformed()
    {
        _acceptExitWindow.Active = true;
        while(_acceptExitWindow.Active) {
            ContentManager.GetScene<GameScene>(Scenes.GAME_SCENE).DrawComponets();
            Update();
        }
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        position.Y+= 5;
        _text.Draw(position, alignX, alignY);
        _acceptExitWindow.Draw(new Vector(Console.WindowWidth / 2, 0), new int[,]{}, AlignX.CENTER, AlignY.TOP);
    }
    internal void Update() {
        switch(_acceptExitWindow.Listen().Y) {
            case 0:
            ContentManager.GetScene(Scenes.GAME_SCENE).SceneActive = false;
            _acceptExitWindow.Active = false;
            break;
            case 1:
            _acceptExitWindow.Active = false;
            break;
        }
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
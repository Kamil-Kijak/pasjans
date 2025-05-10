

public class RestartSection : IPanel {
    private readonly Text _text;
    private readonly ChooseWindow _acceptRestartWindow;
    public RestartSection() {
        _text = new("Restart");
        _acceptRestartWindow = new(new Vector(40, 10), "Napewno chcesz wykonać restart?",
        new IPanel[,]{{new Text("--->Tak<---")}, {new Text("--->Nie<---")}});
    }

    public void ActionPerformed()
    {
        _acceptRestartWindow.Active = true;
        while(_acceptRestartWindow.Active) {
            ContentManager.GetScene<GameScene>(Scenes.GAME_SCENE).DrawComponets();
            Update();
        }
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        position.Y+= 5;
        _text.Draw(position, alignX, alignY);
        _acceptRestartWindow.Draw(new Vector(Console.WindowWidth / 2, 0), new int[,]{}, AlignX.CENTER, AlignY.TOP);
    }
    internal void Update() {
        switch(_acceptRestartWindow.Listen().Y) {
            case 0:
            ContentManager.GetScene(Scenes.GAME_SCENE).SceneActive = false;
            ContentManager.SetScene(Scenes.GAME_SCENE, new GameScene());
            ContentManager.AddSceneToQueue(Scenes.GAME_SCENE);
            _acceptRestartWindow.Active = false;
            break;
            case 1:
            _acceptRestartWindow.Active = false;
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
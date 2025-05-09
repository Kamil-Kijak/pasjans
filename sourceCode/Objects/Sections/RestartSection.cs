

public class RestartSection : IPanel {
    private readonly Text _text;
    public RestartSection() {
        _text = new("Restart");
    }

    public void ActionPerformed()
    {
        ContentManager.GetScene(Scenes.GAME_SCENE).SceneActive = false;
        ContentManager.SetScene(Scenes.GAME_SCENE, new GameScene());
        ContentManager.AddSceneToQueue(Scenes.GAME_SCENE);
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
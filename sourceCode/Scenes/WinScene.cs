

public class WinScene : BaseScene {
    private DrawableObject _title;
    private DrawableObject _leaderBoardBox;
    private Text _scoreText;
    private Text _scores;
    private SelectPanel _afterWinOptions;

    public WinScene() {
        _title = new DrawableObject(Content.GetTextObject(Objects.WINTITLE));
        _leaderBoardBox = DrawManager.CreateBox(46, 30);
        _scores = new("Brak wyników");
        _afterWinOptions = new([
            new Text("--->Zagraj ponownie<---"), new Text("--->Wyjdź<---")
        ], ConsoleColor.Red, 0);
        _scoreText = new("");
    }

    public override void DrawComponets()
    {
        base.DrawComponets();
        _title.Draw(new Vector(Console.WindowWidth / 2, 0), AlignX.CENTER, AlignY.TOP);
        _scoreText.Draw(new Vector(Console.WindowWidth / 2, 8), AlignX.CENTER, AlignY.TOP);
        _leaderBoardBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
        _scores.Draw(new Vector(Console.WindowWidth / 2.5f, 13), AlignX.LEFT, AlignY.TOP); 
        _afterWinOptions.Draw(new Vector(Console.WindowWidth / 2, 44), 1, AlignX.CENTER, AlignY.TOP);
    }
    public override void Update()
    {
        int moves = Content.GetScene<GameScene>(Scenes.GAME_SCENE).UndoSection.Moves;
        _scoreText = new([
            string.Format("Ułożyłeś pasjansa w {0} ruchach", moves),
            "Ranking"]);
        Content.AddNewLeaderBoardScore(new ScoreObject(){DateTime = DateOnly.FromDateTime(DateTime.Now).ToString().Replace('.', '-'),
         Score = moves});
        _scores = new(Content.LoadLeaderBoard());
        base.Update();
        while(_sceneActive) {
            if(_afterWinOptions.IsChoosenState()) {
                switch(_afterWinOptions.Index) {
                    case 0:
                    SceneActive = false;
                    Content.SetScene(Scenes.GAME_SCENE, new GameScene());
                    Content.AddSceneToQueue(Scenes.GAME_SCENE);
                    break;
                    case 1:
                    SceneActive = false;
                    break;
                }
            }
            base.Update();
        }
    }
    private void SaveScore() {

    }
}


public class WinScene : BaseScene {
    private readonly DrawableObject _title;
    private readonly DrawableObject _leaderBoardBox;
    private Text _scoreText;
    private readonly Text _leaderBoardText;
    private Text _scores;
    private readonly SelectPanel2d _afterWinOptions;

    public WinScene() {
        _title = new DrawableObject(ContentManager.GetTextObject(Objects.WIN_TITLE));
        _leaderBoardBox = ContentManager.CreateBox(46, 30);
        _scores = new("Brak wyników");
        _afterWinOptions = new(new IPanel[,]{
            {new Text("--->Zagraj ponownie<---")}, { new Text("--->Wyjdź<---")}
        }, ConsoleColor.Red, new Vector());
        _scoreText = new("");
        _leaderBoardText = new("Ranking");
    }

    public override void DrawComponets()
    {
        base.DrawComponets();
        _title.Draw(new Vector(Console.WindowWidth / 2, 0), AlignX.CENTER, AlignY.TOP);
        _scoreText.Draw(new Vector(Console.WindowWidth / 2, 8), AlignX.CENTER, AlignY.TOP);
        _leaderBoardText.Draw(new Vector(Console.WindowWidth / 2, 10), AlignX.CENTER, AlignY.TOP);
        _leaderBoardBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
        _scores.Draw(new Vector(Console.WindowWidth / 2 - 20, 13), AlignX.LEFT, AlignY.TOP); 
        _afterWinOptions.Draw(new Vector(Console.WindowWidth / 2, 44),true, new int[,]{}, 2, AlignX.CENTER, AlignY.TOP);
    }
    public override void Update()
    {
        SaveScore();
        base.Update();
        while(_sceneActive) {
            if(_afterWinOptions.Listen() == SelectPanel2d.ChooseState.CHOOSEN) {
                switch(_afterWinOptions.Index.Y) {
                    case 0:
                    SceneActive = false;
                    ContentManager.SetScene(Scenes.GAME_SCENE, new GameScene());
                    ContentManager.AddSceneToQueue(Scenes.GAME_SCENE);
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
        int moves = ContentManager.GetScene<GameScene>(Scenes.GAME_SCENE).UndoSection.Moves;
        _scoreText = new(string.Format("Ułożyłeś pasjansa w {0} ruchach", moves));
        LeaderBoardManager.AddNewLeaderBoardScore(new ScoreObject(){
        DateTime = DateOnly.FromDateTime(DateTime.Now).ToString().Replace('.', '-'),
         Score = moves});
        _scores = new(LeaderBoardManager.LoadLeaderBoard());
    }
}
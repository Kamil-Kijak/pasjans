

public class TitleScene : BaseScene {

    private int _states = 0;
    private readonly Text _authorText;
    private readonly DrawableObject _title;
    private readonly SelectPanel2d _gameOptionSelect;
    private readonly SelectPanel2d _difficultySelect;
    private readonly SelectPanel2d _leaderBoardExit;
    private readonly DrawableObject _gameOptionSelectBox;
    private readonly DrawableObject _leaderBoardBox;
    private Text _scores;
    private Difficulty _selectedDifficulty;

    public TitleScene() {
        _authorText = new(["stworzony przez", " ", "Kamila Kijaka"]);
        _title = new (ContentManager.GetTextObject(Objects.TITLE));
        _gameOptionSelect = new(new IPanel[,]{
            {new Text("--->START<---")}, {new Text("--->RANKING<---")}, {new Text("--->WYJŚCIE<---")}
        }, ConsoleColor.Red, new Vector(0, 0));
        _gameOptionSelectBox = ContentManager.CreateBox(21, 10);
        _leaderBoardExit = new(new IPanel[,]{{new Text("--->POWRÓT<---")}}, ConsoleColor.Red, new Vector(0, 0));
        _leaderBoardBox = ContentManager.CreateBox(46, 30);
        _difficultySelect = new(new IPanel[,]{
            {new Text("--->ŁATWY<---")}, {new Text("--->TRUDNY<---")}, {new Text("--->POWRÓT<---")}
        },
             ConsoleColor.Red, new Vector(0, 0));
        _scores = new ("Nie masz jeszcze żadnego wyniku!");
    }

    public override void DrawComponets()
    {
        base.DrawComponets();
        _title.Draw(new Vector(Console.WindowWidth / 2, 0), AlignX.CENTER, AlignY.TOP);
        _authorText.Draw(new Vector(Console.WindowWidth / 2, 7), AlignX.CENTER, AlignY.TOP);
        switch(_states) {
            case 0:
                _gameOptionSelectBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
                _gameOptionSelect.Draw(new Vector(Console.WindowWidth / 2, 13), true, new int[,]{}, 1, AlignX.CENTER);
            break;
            case 1:
                _leaderBoardBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
                _leaderBoardExit.Draw(new Vector(Console.WindowWidth / 2, 42), true, new int[,]{}, 0, AlignX.CENTER);  
                _scores.Draw(new Vector(Console.WindowWidth / 2 - 20, 13), AlignX.LEFT, AlignY.TOP); 
            break;
            case 2:
                _gameOptionSelectBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
                _difficultySelect.Draw(new Vector(Console.WindowWidth / 2, 13), true, new int[,]{}, 1, AlignX.CENTER);
            break;
        }
    }
    public override void Update()
    {
        base.Update();
        string[] leaderBoard = LeaderBoardManager.LoadLeaderBoard();
        if(leaderBoard.Length > 0) {
            _scores = new(leaderBoard);
        }
        while(_sceneActive) {
            switch(_states) {
                case 0:
                    GameOptionSelectListening();
                break;
                case 1:
                    LeaderBoardExitListening();
                break;
                case 2:
                     DifficultySelectListening();
                break;
            }
        }

    }
    internal void GameOptionSelectListening() {
        if(_gameOptionSelect.Listen() == SelectPanel2d.ChooseState.CHOOSEN) {
            switch(_gameOptionSelect.Index.Y) {
                case 0:
                    _states = 2;
                    _difficultySelect.Index = new Vector(0, 0);
                    break;
                case 1:
                    _states = 1;
                break;
                case 2:
                    SceneActive = false;
                break;
            }
        }
        base.Update();
    }
    internal void DifficultySelectListening() {
        if(_difficultySelect.Listen() == SelectPanel2d.ChooseState.CHOOSEN) {
            switch(_difficultySelect.Index.Y) {
                case 0:
                    _selectedDifficulty = Difficulty.EASY;
                    SceneActive = false;
                    ContentManager.AddSceneToQueue(Scenes.GAME_SCENE);
                    break;
                case 1:
                    _selectedDifficulty = Difficulty.HARD;
                    SceneActive = false;
                    ContentManager.AddSceneToQueue(Scenes.GAME_SCENE);
                    break;
                case 2:
                _states = 0;
                break;
            }
        }
        base.Update();
    }
    internal void LeaderBoardExitListening() {
        if(_leaderBoardExit.Listen() == SelectPanel2d.ChooseState.CHOOSEN) {
            _states = 0;
        }
        base.Update();
    }
    public Difficulty SelectedDifficulty {
        get { return _selectedDifficulty; }
    } 
}

using System.Text.Json;

public class TitleScene : BaseScene {

    private int _states = 0;
    private Text _authorText;
    private DrawableObject _title;
    private SelectPanel _gameOptionSelect;
    private SelectPanel _difficultySelect;
    private SelectPanel _leaderBoardExit;
    private DrawableObject _gameOptionSelectBox;
    private DrawableObject _leaderBoardBox;
    private Text _scores;
    private Difficulty _selectedDifficulty;

    public TitleScene() {
        _authorText = new(["stworzony przez", " ", "Kamila Kijaka"]);
        _title = new (Content.GetTextObject(Objects.TITLE));
        _gameOptionSelect = new([
            new Text("--->START<---"), new Text("--->RANKING<---"), new Text("--->WYJŚCIE<---")
        ], ConsoleColor.Red, 0);
        _gameOptionSelectBox = DrawManager.CreateBox(21, 10);
        _leaderBoardExit = new([
            new Text("--->POWRÓT<---"),
        ], ConsoleColor.Red);
        _leaderBoardBox = DrawManager.CreateBox(46, 30);
        _difficultySelect = new([
            new Text("--->ŁATWY<---"), new Text("--->TRUDNY<---"), new Text("--->POWRÓT<---")
        ], ConsoleColor.Red, 0);
        _scores = new (["Nie masz jeszcze żadnego", "wyniku!"]);
    }

    protected override void DrawComponets()
    {
        base.DrawComponets();
        _title.Draw(new Vector(Console.WindowWidth / 2, 0), AlignX.CENTER, AlignY.TOP);
        _authorText.Draw(new Vector(Console.WindowWidth / 2, 7), AlignX.CENTER, AlignY.TOP);
        switch(_states) {
            case 0:
                _gameOptionSelectBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
                _gameOptionSelect.Draw(new Vector(Console.WindowWidth / 2, 13), 1, AlignX.CENTER);
            break;
            case 1:
                _leaderBoardBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
                _leaderBoardExit.Draw(new Vector(Console.WindowWidth / 2, 42), 0, AlignX.CENTER);  
                _scores.Draw(new Vector(Console.WindowWidth / 2, 13), AlignX.CENTER, AlignY.TOP); 
            break;
            case 2:
                _gameOptionSelectBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
                _difficultySelect.Draw(new Vector(Console.WindowWidth / 2, 13), 1, AlignX.CENTER);
            break;
        }
    }
    public override void Update()
    {
        base.Update();
        LoadLeaderBoard();
        while(_sceneActive) {
            switch(_states) {
                case 0:
                    if(ChoosenState(_gameOptionSelect)) {
                    switch(_gameOptionSelect.Index) {
                        case 0:
                            _states = 2;
                            _difficultySelect.Index = 0;
                            break;
                        case 1:
                            _states = 1;
                        break;
                        case 2:
                        return;
                    }
                }
                base.Update();
                break;
                case 1:
                    if(ChoosenState(_leaderBoardExit)) {
                        _states = 0;
                    }
                    base.Update();
                break;
                case 2:
                    if(ChoosenState(_difficultySelect)) {
                        switch(_difficultySelect.Index) {
                            case 0:
                                _selectedDifficulty = Difficulty.EASY;
                                SceneActive = false;
                                Content.GetScene(Scenes.GAME_SCENE).SceneActive = true;
                               break;
                            case 1:
                                _selectedDifficulty = Difficulty.HARD;
                                SceneActive = false;
                                Content.GetScene(Scenes.GAME_SCENE).SceneActive = true;
                                break;
                            case 2:
                            _states = 0;
                            break;
                        }
                    }
                    base.Update();
                        
                break;
            }
        }

    }
    internal bool ChoosenState(SelectPanel  selectPanel) {
        if(selectPanel.Listen() == SelectPanel.ChooseState.CHOOSEN) {
            return true;
        } else {
            return false;
        }
    }
    private void LoadLeaderBoard() {
        if(!File.Exists(Path.Combine(Content.AppPath, "leaderboard.json"))) {
            File.WriteAllLines(Path.Combine(Content.AppPath, "leaderboard.json"), ["[]"]);
        } else {
            string leaderboard = File.ReadAllText(Path.Combine(Content.AppPath, "leaderboard.json"));
            List<ScoreObject>? list = JsonSerializer.Deserialize<List<ScoreObject>>(leaderboard);
            list?.Sort(new ScoreComparator());
            if(list != null) {
                string[] rows = new string[list.Count];
                for (int i = 0; i < list.Count; i++) {
                    rows[i] = new(string.Format("#{0}    data:{1}    ruchy:{2}", i + 1, list[i].DateTime, list[i].Score));
                }
                _scores = new(rows);
            }
        }
    }
    public Difficulty SelectedDifficulty {
        get { return _selectedDifficulty; }
    } 
}
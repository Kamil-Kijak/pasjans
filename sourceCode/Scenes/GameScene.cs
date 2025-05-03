
public class GameScene : BaseScene {
    private int _moves;
    private Text _movesText;
    private Difficulty _difficulty;
    private CardStack _cardStack;
    private PickedCards _pickedCards;
    private UndoSection _undoSection;
    private SelectPanel2d _selectPanel2d;
    private Dictionary<EndStacks, EndStack> _endStacks;
    private IPanel[,] _gameObjects;

    public GameScene() {
        _moves = 0;
        _pickedCards = new();
        _cardStack = new();
        _undoSection = new();
        _endStacks = new(){
            {EndStacks.HEART, new EndStack(Objects.HEART)},
            {EndStacks.DIAMOND, new EndStack(Objects.DIAMOND)},
            {EndStacks.SPADE, new EndStack(Objects.SPADE)},
            {EndStacks.TREFL, new EndStack(Objects.TREFL)}
        };
        _gameObjects = new IPanel[,] {
            {_cardStack, _pickedCards, _undoSection,
             _endStacks[EndStacks.HEART], _endStacks[EndStacks.DIAMOND], _endStacks[EndStacks.SPADE], _endStacks[EndStacks.TREFL]}
        };
        _selectPanel2d = new(_gameObjects, ConsoleColor.DarkYellow, new Vector(1, 0));
        _movesText = new("Ruchy: 0");
    }

    protected override void DrawComponets()
    {
        base.DrawComponets();
        _selectPanel2d.Draw(new Vector(1, 1), true, [3, 13, 10, 3, 3, 3, 0]);
        _movesText.Draw(new Vector(Console.WindowWidth / 3, 1), AlignX.CENTER, AlignY.TOP);
    }
    public override void Update()
    {
        base.Update();
        TitleScene titleScene = Content.GetScene<TitleScene>(Scenes.TITLE_SCENE);
        _difficulty = titleScene.SelectedDifficulty;
        while(true) {
            SelectPanel2d.ChooseState chooseState =_selectPanel2d.Listen();
            if(chooseState == SelectPanel2d.ChooseState.CHOOSEN) {
                _gameObjects[(int)_selectPanel2d.Index.Y, (int)_selectPanel2d.Index.X].ActionPerformed();
            }
            base.Update();
        }
    }
    public PickedCards PickedCards {
        get {return _pickedCards;}
    }
    public CardStack CardStack {
        get {return _cardStack;}
    }
    public Difficulty Difficulty {
        get {return _difficulty;}
    }
    public int Moves {
        get {return _moves;}
        set {
            _moves = value;
            _movesText.Lines = ["Ruchy: " + _moves.ToString()];
        }
    }
}
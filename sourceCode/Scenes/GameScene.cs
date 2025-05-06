
public class GameScene : BaseScene {
    private Difficulty _difficulty;
    private CardStack _cardStack;
    private PickedCards _pickedCards;
    private UndoSection _undoSection;
    private RestartSection _restartSection;
    private ExitSection _exitSection;
    private SelectPanel2d _selectPanel2d;
    private Dictionary<EndStacks, EndStack> _endStacks;
    private CardColumn[] _cardsColumns;
    private IPanel[,] _gameObjects;

    public GameScene() {
        _pickedCards = new();
        _cardStack = new();
        _undoSection = new();
        _restartSection = new();
        _exitSection = new();
        _endStacks = new(){
            {EndStacks.HEART, new EndStack(Objects.HEART, '♥')},
            {EndStacks.DIAMOND, new EndStack(Objects.DIAMOND, '♦')},
            {EndStacks.SPADE, new EndStack(Objects.SPADE, '♠')},
            {EndStacks.TREFL, new EndStack(Objects.TREFL, '♣')}
        };
        _cardsColumns = new CardColumn[7];
        for (int i = 0; i < 7; i++) {
            _cardsColumns[i] = new CardColumn(_cardsColumns.Length - i, _cardStack);
        }
        _gameObjects = new IPanel[,] {
            {
                _cardStack, _pickedCards, _undoSection, _endStacks[EndStacks.HEART],
                _endStacks[EndStacks.DIAMOND], _endStacks[EndStacks.SPADE], _endStacks[EndStacks.TREFL], _restartSection
            },
            {
                _cardsColumns[0], _cardsColumns[1], _cardsColumns[2], _cardsColumns[3],
                _cardsColumns[4],_cardsColumns[5], _cardsColumns[6], _exitSection
            }
        };
        _selectPanel2d = new(_gameObjects, ConsoleColor.DarkYellow, new Vector(0, 0));
    }

    public override void DrawComponets()
    {
        base.DrawComponets();
        _selectPanel2d.Draw(new Vector(1, 1), !_cardsColumns.Any(column => column.Selected), new int[,]{
            {6, 9, 1, 6, 6, 6, 2, 6},
            {6, 6, 6, 6, 6, 6, 2, 0}
            }, 1);
    }
    public override void Update()
    {
        base.Update();
        TitleScene titleScene = Content.GetScene<TitleScene>(Scenes.TITLE_SCENE);
        _difficulty = titleScene.SelectedDifficulty;
        while(_sceneActive) {
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
    public RestartSection RestartSection {
        get {return _restartSection;}
    }
    public UndoSection UndoSection {
        get {return _undoSection;}
    }
    public Dictionary<EndStacks, EndStack> EndStacksDict {
        get {return _endStacks;}
    }
    public Difficulty Difficulty {
        get {return _difficulty;}
    }
}

public class GameScene : BaseScene {
    private Difficulty _difficulty;
    private readonly CardStack _cardStack;
    private readonly PickedCards _pickedCards;
    private readonly UndoSection _undoSection;
    private readonly RestartSection _restartSection;
    private readonly ExitSection _exitSection;
    private readonly SelectPanel2d _selectPanel2d;
    private readonly Dictionary<EndStacks, EndStack> _endStacks;
    private readonly CardColumn[] _cardsColumns;
    private readonly IPanel[,] _gameObjects;
    private readonly ICardContainer[] _cardContainers;

    public GameScene() {
        _pickedCards = new();
        _cardStack = new();
        _restartSection = new();
        _exitSection = new();
        _endStacks = new(){
            {EndStacks.HEART, new EndStack(Objects.HEART, '♥')},
            {EndStacks.DIAMOND, new EndStack(Objects.DIAMOND, '♦')},
            {EndStacks.SPADE, new EndStack(Objects.SPADE, '♠')},
            {EndStacks.TREFL, new EndStack(Objects.TREFL, '♣')}
        };
        _cardsColumns = new CardColumn[7];
        _cardContainers = new ICardContainer[11];
        CreateCardsColumns();
        
        _undoSection = new(this);
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
            {6, 9, 1, 6, 6, 6, 2},
            {6, 6, 6, 6, 6, 6, 2}
            }, 1);
    }
    public override void Update()
    {
        base.Update();
        TitleScene titleScene = ContentManager.GetScene<TitleScene>(Scenes.TITLE_SCENE);
        _difficulty = titleScene.SelectedDifficulty;
        while(_sceneActive) {
            SelectPanel2d.ChooseState chooseState =_selectPanel2d.Listen();
            if(chooseState == SelectPanel2d.ChooseState.CHOOSEN) {
                _gameObjects[(int)_selectPanel2d.Index.Y, (int)_selectPanel2d.Index.X].ActionPerformed();
            }
            base.Update();
        }
    }
    internal void CreateCardsColumns() {
        _cardContainers[0] = _endStacks[EndStacks.HEART];
        _cardContainers[1] = _endStacks[EndStacks.DIAMOND];
        _cardContainers[2] = _endStacks[EndStacks.SPADE];
        _cardContainers[3] = _endStacks[EndStacks.TREFL];
        for (int i = 0; i < 7; i++) {
            _cardsColumns[i] = new CardColumn(_cardsColumns.Length - i, _cardStack);
            _cardContainers[i + 4] = _cardsColumns[i];
        }
    }
    public PickedCards PickedCards {
        get {return _pickedCards;}
    }
    public CardStack CardStack {
        get {return _cardStack;}
    }
    public UndoSection UndoSection {
        get {return _undoSection;}
    }
    public CardColumn[] CardColumns {
        get {return _cardsColumns;}
    }
    public ICardContainer[] CardContainers {
        get {return _cardContainers;}
    }
    public Dictionary<EndStacks, EndStack> EndStacksDict {
        get {return _endStacks;}
    }
    public Difficulty Difficulty {
        get {return _difficulty;}
    }
}
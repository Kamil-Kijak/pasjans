
public class GameScene : BaseScene {
    private Random _random;
    private Difficulty _difficulty;
    private CardStack _cardStack;
    private PickedCards _pickedCards;
    private SelectPanel2d _selectPanel2d;
    private IPanel[,] _gameObjects;

    public GameScene() {
        _pickedCards = new();
        _random = new();
        _cardStack = new();
        _gameObjects = new IPanel[,] {
            {_cardStack, _pickedCards}
        };
        _selectPanel2d = new(_gameObjects, ConsoleColor.DarkYellow, new Vector(1, 0));
    }

    protected override void DrawComponets()
    {
        base.DrawComponets();
        _selectPanel2d.Draw(new Vector(1, 1), 3);
    }
    public override void Update()
    {
        base.Update();
        if(Content.GetScene(Scenes.TITLE_SCENE) is TitleScene titleScene) {
            _difficulty = titleScene.SelectedDifficulty;
        }
        while(true) {
            SelectPanel2d.ChooseState chooseState =_selectPanel2d.Listen();
            if(chooseState == SelectPanel2d.ChooseState.CHOOSEN) {
                _gameObjects[(int)_selectPanel2d.Index.Y, (int)_selectPanel2d.Index.Y].ActionPerformed();
            }
            base.Update();
        }
    }
}
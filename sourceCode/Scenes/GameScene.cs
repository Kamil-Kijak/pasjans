
public class GameScene : BaseScene {
    private Random _random;
    private Difficulty _difficulty;
    private CardStack _cardStack;
    private PickedCards _pickedCards;
    private SelectPanel2d _selectPanel2d;

    public GameScene() {
        _pickedCards = new();
        _random = new();
        _cardStack = new();
        _selectPanel2d = new(new IPanel[,] {
            {_cardStack, _pickedCards}
        }, ConsoleColor.DarkYellow, new Vector(1, 0));
    }

    protected override void DrawComponets()
    {
        base.DrawComponets();
        // _cardStack.Draw(new Vector(1, 1));
        // _pickedCards.Draw(new Vector(25, 1));
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

            }
            base.Update();
        }
    }
}
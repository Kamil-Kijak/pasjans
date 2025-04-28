
public class GameScene : BaseScene {
    private Random _random;
    private Difficulty _difficulty;
    private List<Card> _cardStack;
    private List<Card> _pickedCards;
    private DrawableObject _pickedCardsPlace;

    public GameScene() {
        _cardStack = new();
        _pickedCards = new();
        _random = new();
        char[] characters = {'♥', '♦', '♠', '♣'};
        string[] symbols = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        foreach (char character in characters) {
            foreach (string symbol in symbols) {
                _cardStack.Add(new Card(symbol, character, true));
            }
        }
        Shuffle(_cardStack);
        _pickedCardsPlace = DrawManager.CreateBox(15, 11);
    }

    protected override void DrawComponets()
    {
        base.DrawComponets();
        if(_cardStack.Count > 0) {
            _cardStack[_cardStack.Count - 1].Draw(new Vector(1, 1));
        }
        if(_pickedCards.Count == 0) {
            _pickedCardsPlace.Draw(new Vector(25, 1));
        } else {
            _pickedCards[_pickedCards.Count - 1].Draw(new Vector(25, 1));
        }
    }
    public override void Update()
    {
        base.Update();
        if(Content.GetScene(Scenes.TITLE_SCENE) is TitleScene titleScene) {
            _difficulty = titleScene.SelectedDifficulty;
        }
        while(true) {

        }
    }
    public void Shuffle(List<Card> cards) {
        // shuffle algoritm
        int j;
        for(int i = cards.Count - 1;i > 0;i--) {
            j = _random.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }
}
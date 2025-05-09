

public class EndStack : StateObject ,IPanel, ICardContainer {
    private readonly DrawableObject _cardBody;
    private readonly DrawableObject _symbol;
    private readonly List<Card> _cards;
    private readonly char _character;
    private bool _completed;
    public static string[] _symbolOrder = ["A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];
    public EndStack(Objects cardSymbol, char character): base(3) {
        _cardBody = new(string.Format(ContentManager.GetTextObject(Objects.CARD_BODY), "  ", " "), ConsoleColor.DarkGray);
        _symbol = new(ContentManager.GetTextObject(cardSymbol), ConsoleColor.DarkGray);
        _character = character;
        _cards = [];
        _completed = false;
        ActualState = _cards;
    }


    public void ActionPerformed()
    {
        
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        if(_cards.Count == 0) {
            _cardBody.Draw(position, alignX, alignY);
            position.X += 3;
            position.Y += 3;
            _symbol.Draw(position, alignX, alignY);
        } else {
            _cards[^1].Draw(position, alignX, alignY);
        }
    }

    public void AddToStack(Card[] cards)
    {
        _cards.Add(cards[0].Copy());
        if(_cards.Count == _symbolOrder.Length) {
            _completed = true;
            GameScene gameScene = ContentManager.GetScene<GameScene>(Scenes.GAME_SCENE);
            if(gameScene.EndStacksDict.All(element => element.Value._completed)) {
                gameScene.SceneActive = false;
                ContentManager.AddSceneToQueue(Scenes.WIN_SCENE);
            }
        }
    }

    public bool IsCardsBeAdded(Card[] cards)
    {
        if(!_completed && _character == cards[0].Character) {
            if(cards.Length == 1) {
                if(_symbolOrder[_cards.Count] == cards[0].Symbol) {
                    return true;
                }
            }
        }
        return false;
    }

    public ConsoleColor ForegroundColor {
        get {
            if(_cards.Count == 0) {
                return _cardBody.ForegroundColor;
            } else {
                return _cards[^1].ForegroundColor;
            }
        }
        set {
            if(_cards.Count == 0) {
                _cardBody.ForegroundColor = value;
                _symbol.ForegroundColor = value;
            } else {
                _cards[^1].ForegroundColor = value;
            }
        }
    }
    public int Width {
        get {
            return _cardBody.Width;
        }
    }
    public int Height {
        get {
            return _cardBody.Height;
        }
    }
}
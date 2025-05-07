

public class EndStack : StateObject ,IPanel, ICardContainer {
    private DrawableObject _cardBody;
    private DrawableObject _symbol;
    private List<Card> _cards;
    private char _character;
    private bool _completed;
    public static string[] _symbolOrder = ["A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"];
    public EndStack(Objects cardSymbol, char character): base(3) {
        _cardBody = new(string.Format(Content.GetTextObject(Objects.CARD_BODY), "  ", " "), ConsoleColor.DarkGray, ConsoleColor.Black);
        _symbol = new(Content.GetTextObject(cardSymbol), ConsoleColor.DarkGray, ConsoleColor.Black);
        _character = character;
        _cards = new();
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
    public ConsoleColor BackgroundColor {
        get {
            if(_cards.Count == 0) {
                return _cardBody.BackgroundColor;
            } else {
                return _cards[^1].BackgroundColor;
            }
        }
        set {
            if(_cards.Count == 0) {
                _cardBody.BackgroundColor = value;
                _symbol.BackgroundColor = value;
            } else {
                _cards[^1].BackgroundColor = value;
            }
        }
    }
    public int Width {
        get {
            return _cardBody.Width;
        }
        set {
            _cardBody.Width = value;
            _symbol.Width = value;
        }
    }
    public int Height {
        get {
            return _cardBody.Height;
        }
        set {
            _cardBody.Height = value;
            _symbol.Height = value;
        }
    }
}
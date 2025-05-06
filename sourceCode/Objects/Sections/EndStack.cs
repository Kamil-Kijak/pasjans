

public class EndStack : StateObject ,IPanel {
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
    }


    public void ActionPerformed()
    {
        
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        _cardBody.Draw(position, alignX, alignY);
        position.X += 3;
        position.Y += 3;
        _symbol.Draw(position, alignX, alignY);
    }
    public bool AddCard(Card card) {
        if(_character == card.Character && !_completed) {
            if(_symbolOrder[_cards.Count] == card.Symbol) {
                _cards.Add(card);
                if(_cards.Count == _symbolOrder.Length) {
                    _completed = true;
                }
                return true;
            }
        }
        return false;
    }
    public ConsoleColor ForegroundColor {
        get {
            return _cardBody.ForegroundColor;
        }
        set {
            _cardBody.ForegroundColor = value;
            _symbol.ForegroundColor = value;
        }
    }
    public ConsoleColor BackgroundColor {
        get {
            return _cardBody.BackgroundColor;
        }
        set {
            _cardBody.BackgroundColor = value;
            _symbol.BackgroundColor = value;
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
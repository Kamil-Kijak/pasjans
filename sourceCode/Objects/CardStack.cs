

public class CardStack : IPanel
{
    private List<Card> _cardStackList;
    private DrawableObject _pickedCardsPlace;
    private static Random _random = new Random();

    public CardStack() {
        _cardStackList = new();
        _pickedCardsPlace = DrawManager.CreateBox(15, 11);
        char[] characters = {'♥', '♦', '♠', '♣'};
        string[] symbols = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        foreach (char character in characters) {
            foreach (string symbol in symbols) {
                CardStackList.Add(new Card(symbol, character, true));
            }
        }
        Shuffle(CardStackList);
    }
    private void Shuffle(List<Card> cards) {
        // shuffle algoritm
        int j;
        for(int i = cards.Count - 1;i > 0;i--) {
            j = _random.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }

    public void Draw(Vector position)
    {
        if(_cardStackList.Count > 0) {
            _cardStackList[^1].Draw(position);
        } else {
            _pickedCardsPlace.Draw(position);
        }
    }

    public void Draw(Vector position, AlignX alignX, AlignY alignY)
    {
        Draw(position);
    }

    public List<Card> CardStackList {
        get {
            return _cardStackList;
        }
    }

    public ConsoleColor ForegroundColor {
        get {
             if(_cardStackList.Count > 0) {
                return _cardStackList[^1].ForegroundColor;
            } else {
                return _pickedCardsPlace.ForegroundColor;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].ForegroundColor = value;
            } else {
                _pickedCardsPlace.ForegroundColor = value;
            }
        }
    }
    public ConsoleColor BackgroundColor {
         get {
             if(_cardStackList.Count > 0) {
                return _cardStackList[^1].BackgroundColor;
            } else {
                return _pickedCardsPlace.BackgroundColor;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].BackgroundColor = value;
            } else {
                _pickedCardsPlace.BackgroundColor = value;
            }
        }
         }
    public int Width {
         get {
             if(_cardStackList.Count > 0) {
                return _cardStackList[^1].Width;
            } else {
                return _pickedCardsPlace.Width;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].Width = value;
            } else {
                _pickedCardsPlace.Width = value;
            }
        }
         }
    public int Height {
        get {
             if(_cardStackList.Count > 0) {
                return _cardStackList[^1].Height;
            } else {
                return _pickedCardsPlace.Height;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].Height = value;
            } else {
                _pickedCardsPlace.Height = value;
            }
        }
    }
}
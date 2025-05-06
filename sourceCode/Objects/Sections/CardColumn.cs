

public class CardColumn : IPanel {
    private List<Card> _cards;
    private DrawableObject _cardPlace;
    private bool _selected = false;
    private int _selectIndex;
    public CardColumn(int cardsNumber, CardStack cardStack) {
        _cards = new();
        _cardPlace = new DrawableObject(Content.GetTextObject(Objects.CARD_BODY));
        Card cardToAdd;
        for (int i = 0; i < cardsNumber; i++) {
            cardToAdd = cardStack.GetFirstCard();
            cardToAdd.Showed = cardsNumber == i + 1;
            _cards.Add(cardToAdd);
        }
    }

    public void ActionPerformed()
    {
        if(_cards.Count != 0) {
            _selectIndex = _cards.Count - 1;
            _selected = true;
            Content.GetScene(Scenes.GAME_SCENE).DrawComponets();
            ConsoleKey key;
            while(_selected) {
                key = Console.ReadKey().Key;
                switch(key) {
                    case ConsoleKey.W:
                        if(_selectIndex > 0) {
                            _selectIndex--;
                        }
                        if(!_cards[_selectIndex].Showed) {
                            _selectIndex++;
                        }
                    break;
                    case ConsoleKey.S:
                        if(_selectIndex < _cards.Count - 1) {
                            _selectIndex++;
                        }
                    break;
                    case ConsoleKey.Enter:
                    _selected = false;
                    break;
                }
                Content.GetScene(Scenes.GAME_SCENE).DrawComponets();
            }
        }
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        if(!_selected) {
            for (int i = 0; i < _cards.Count; i++) {
                _cards[i].Draw(new Vector(position.X, position.Y + i*3), alignX, alignY);
            }
        } else {
            for (int i = _selectIndex; i < _cards.Count; i++) {
                _cards[i].Draw(new Vector(position.X, position.Y + i*3), alignX, alignY);
            }
        }
    }
    public bool Selected {
        get { return _selected; }
    }
    public ConsoleColor ForegroundColor {
         get {
            if(_cards.Count > 0) {
                return _cards[^1].ForegroundColor;
            } else {
                return _cardPlace.ForegroundColor;
            }
         }
         set {
            _cardPlace.ForegroundColor = value;
            if(_cards.Count > 0) {
                _cards[^1].ForegroundColor = value;
            }
         }
    }
    public ConsoleColor BackgroundColor {
         get {
            if(_cards.Count > 0) {
                return _cards[^1].BackgroundColor;
            } else {
                return _cardPlace.BackgroundColor;
            }
         }
         set {
            _cardPlace.BackgroundColor = value;
            if(_cards.Count > 0) {
                _cards[^1].BackgroundColor = value;
            }
         }
    }
    public int Width {
        get {
            if(_cards.Count > 0) {
                return _cards[^1].Width;
            } else {
                return _cardPlace.Width;
            }
         }
         set {
            _cardPlace.Width = value;
         }
    }
    public int Height {
        get {
            if(_cards.Count > 0) {
                return _cards[^1].Height;
            } else {
                return _cardPlace.Height;
            }
         }
         set {
            _cardPlace.Height = value;
         }
    }
}
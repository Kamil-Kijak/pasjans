


public class PickedCards : IPanel
{
    private List<Card> _pickedCardsList;
    private DrawableObject _pickedCardsPlace;
    public PickedCards() {
        _pickedCardsList = new();
        _pickedCardsPlace = DrawManager.CreateBox(15, 11);
    }

    public void Draw(Vector position)
    {
        for(int i = Math.Min(3, _pickedCardsList.Count);i>0;i--) {
            _pickedCardsList[_pickedCardsList.Count - i].Draw(new Vector(position.X + (i - 1) * 4, position.Y));
        }
        if(_pickedCardsList.Count == 0) {

            _pickedCardsPlace.Draw(position);
        }
    }

    public void Draw(Vector position, AlignX alignX, AlignY alignY)
    {
        Draw(position);
    }

    public void ActionPerformed()
    {
        throw new NotImplementedException();
    }
    public void AddCard(Card card) {
        _pickedCardsList.Add(card);
    }
    private Card GetFirstCard() {
        Card cardCopy = _pickedCardsList[^1].Copy();
        _pickedCardsList.RemoveAt(_pickedCardsList.Count - 1);
        return cardCopy;
    }
    public Card[] GetAllCards() {
        Card[] cards =  _pickedCardsList.ToArray();
        _pickedCardsList.Clear();
        return cards;
    }
    public ConsoleColor ForegroundColor {
        get {
             if(_pickedCardsList.Count > 0) {
                return _pickedCardsList[^1].ForegroundColor;
            } else {
                return _pickedCardsPlace.ForegroundColor;
            }
        }
        set {
             if(_pickedCardsList.Count > 0) {
                _pickedCardsList[^1].ForegroundColor = value;
            } else {
                _pickedCardsPlace.ForegroundColor = value;
            }
        }
    }
    public ConsoleColor BackgroundColor {
         get {
             if(_pickedCardsList.Count > 0) {
                return _pickedCardsList[^1].BackgroundColor;
            } else {
                return _pickedCardsPlace.BackgroundColor;
            }
        }
        set {
             if(_pickedCardsList.Count > 0) {
                _pickedCardsList[^1].BackgroundColor = value;
            } else {
                _pickedCardsPlace.BackgroundColor = value;
            }
        }
         }
    public int Width {
         get {
             if(_pickedCardsList.Count > 0) {
                return _pickedCardsList[^1].Width;
            } else {
                return _pickedCardsPlace.Width;
            }
        }
        set {
             if(_pickedCardsList.Count > 0) {
                _pickedCardsList[^1].Width = value;
            } else {
                _pickedCardsPlace.Width = value;
            }
        }
         }
    public int Height {
        get {
             if(_pickedCardsList.Count > 0) {
                return _pickedCardsList[^1].Height;
            } else {
                return _pickedCardsPlace.Height;
            }
        }
        set {
             if(_pickedCardsList.Count > 0) {
                _pickedCardsList[^1].Height = value;
            } else {
                _pickedCardsPlace.Height = value;
            }
        }
    }

}
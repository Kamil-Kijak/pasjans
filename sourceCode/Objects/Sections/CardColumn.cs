

public class CardColumn : StateObject,IPanel, ICardContainer {
    private List<Card> _cards;
    private DrawableObject _cardPlace;
    private bool _selected = false;
    private int _selectIndex;
    public static string[] _symbolOrder = EndStack._symbolOrder.Reverse().ToArray();
    public CardColumn(int cardsNumber, CardStack cardStack) : base(3) {
        _cards = new();
        _cardPlace = new DrawableObject(string.Format(Content.GetTextObject(Objects.CARD_BODY), "  ", ' '));
        Card cardToAdd;
        for (int i = 0; i < cardsNumber; i++) {
            cardToAdd = cardStack.GetFirstCard();
            cardToAdd.Showed = cardsNumber == i + 1;
            _cards.Add(cardToAdd);
        }
        ActualState = _cards;
    }

    public void ActionPerformed()
    {
        if(_cards.Count != 0) {
            _selectIndex = _cards.Count - 1;
            _selected = true;
            Content.GetScene<GameScene>(Scenes.GAME_SCENE).DrawComponets();
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
                        Card[] cardsToMove = _cards.GetRange(_selectIndex, _cards.Count - _selectIndex).ToArray();
                        GameScene gameScene = Content.GetScene<GameScene>(Scenes.GAME_SCENE);
                        foreach (ICardContainer cardContainer in gameScene.CardContainers) {
                            if(cardContainer.IsCardsBeAdded(cardsToMove)) {
                                gameScene.UndoSection.AddMove();
                                cardContainer.AddToStack(cardsToMove);
                                foreach (Card card in cardsToMove) {
                                    _cards.Remove(card);
                                }
                                if(_cards.Count != 0) {
                                    _cards[^1].Showed = true;
                                }
                                break;
                            }
                        }
                        _selected = false;
                    break;
                }
                Content.GetScene<GameScene>(Scenes.GAME_SCENE).DrawComponets();
            }
        }
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        if(_cards.Count != 0) {
            if(!_selected) {
                for (int i = 0; i < _cards.Count; i++) {
                    _cards[i].Draw(new Vector(position.X, position.Y + i*3), alignX, alignY);
                }
            } else {
                for (int i = _selectIndex; i < _cards.Count; i++) {
                    _cards[i].Draw(new Vector(position.X, position.Y + i*3), alignX, alignY);
                }
            }
        } else {
            _cardPlace.Draw(position, alignX, alignY);
        }
    }

    public void AddToStack(Card[] cards)
    {
        foreach (Card card in cards) {
            _cards.Add(card.Copy());
        }
    }

    public bool IsCardsBeAdded(Card[] cards)
    {
        if(_cards.Count == 0) {
            if(cards[0].Symbol == "K") {
                return true;
            }
        } else {
            if(cards[0].CardColor != _cards[^1].CardColor) {
                if(Array.IndexOf(_symbolOrder, cards[0].Symbol) - 1 == Array.IndexOf(_symbolOrder, _cards[^1].Symbol)) {
                    return true;
                }
            }
        }
        return false;
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
            if(_cards.Count > 0) {
                _cards[^1].ForegroundColor = value;
            } else {
                _cardPlace.ForegroundColor = value;
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
            if(_cards.Count > 0) {
                _cards[^1].BackgroundColor = value;
            } else {
                _cardPlace.BackgroundColor = value;
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


public class CardStack : IPanel
{
    private List<Card> _cardStackList;
    private DrawableObject _cardStackPlace;
    private static Random _random = new Random();

    public CardStack() {
        _cardStackList = new();
        _cardStackPlace = DrawManager.CreateBox(15, 11);
        char[] characters = {'♥', '♦', '♠', '♣'};
        string[] symbols = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        foreach (char character in characters) {
            foreach (string symbol in symbols) {
                _cardStackList.Add(new Card(symbol, character, false));
            }
        }
        Shuffle(_cardStackList);
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
            _cardStackPlace.Draw(position);
        }
    }

    public void Draw(Vector position, AlignX alignX, AlignY alignY)
    {
        Draw(position);
    }
    public void ActionPerformed()
    {
        GameScene gameScene = Content.GetScene<GameScene>(Scenes.GAME_SCENE);
        Card cardToAdd;
        if(_cardStackList.Count == 0) {
            ReShuffleCards(gameScene.PickedCards.GetAllCards());
        } else {
            if(gameScene.Difficulty == Difficulty.EASY) {
                cardToAdd = GetFirstCard();
                cardToAdd.Showed = true;
                gameScene.PickedCards.AddCard(cardToAdd); 
            } else {
                for (int i = 0; i < 3; i++) {
                    cardToAdd = GetFirstCard();
                    cardToAdd.Showed = true;
                    gameScene.PickedCards.AddCard(cardToAdd);
                    if(_cardStackList.Count == 0) {
                        break;
                    } 
                }
            }
        }
    }
    public Card GetFirstCard() {
        Card cardCopy = _cardStackList[^1].Copy();
        _cardStackList.RemoveAt(_cardStackList.Count - 1);
        return cardCopy;
    }
    private void ReShuffleCards(Card[] pickedCards) {
        foreach (Card card in pickedCards) {
            _cardStackList.Add(card);
        }
        Shuffle(_cardStackList);
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
                return _cardStackPlace.ForegroundColor;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].ForegroundColor = value;
            } else {
                _cardStackPlace.ForegroundColor = value;
            }
        }
    }
    public ConsoleColor BackgroundColor {
         get {
             if(_cardStackList.Count > 0) {
                return _cardStackList[^1].BackgroundColor;
            } else {
                return _cardStackPlace.BackgroundColor;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].BackgroundColor = value;
            } else {
                _cardStackPlace.BackgroundColor = value;
            }
        }
         }
    public int Width {
         get {
             if(_cardStackList.Count > 0) {
                return _cardStackList[^1].Width;
            } else {
                return _cardStackPlace.Width;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].Width = value;
            } else {
                _cardStackPlace.Width = value;
            }
        }
         }
    public int Height {
        get {
             if(_cardStackList.Count > 0) {
                return _cardStackList[^1].Height;
            } else {
                return _cardStackPlace.Height;
            }
        }
        set {
             if(_cardStackList.Count > 0) {
                _cardStackList[^1].Height = value;
            } else {
                _cardStackPlace.Height = value;
            }
        }
    }
}
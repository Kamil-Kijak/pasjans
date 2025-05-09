


public class PickedCards : StateObject, IPanel
{
    public List<Card> _pickedCardsList;
    private readonly DrawableObject _pickedCardsPlace;
    public PickedCards() : base(3) {
        _pickedCardsList = [];
        _pickedCardsPlace = ContentManager.CreateBox(15, 11);
        ActualState = _pickedCardsList;
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        for(int i = Math.Min(3, _pickedCardsList.Count);i>0;i--) {
            _pickedCardsList[^i].Draw(new Vector(position.X + (i - 1) * 4, position.Y), alignX, alignY);
        }
        if(_pickedCardsList.Count == 0) {

            _pickedCardsPlace.Draw(position, alignX, alignY);
        }
    }

    public void ActionPerformed()
    {
        if(_pickedCardsList.Count != 0) {
            Card[] cardsToMove = [_pickedCardsList[^1]];
            GameScene gameScene = ContentManager.GetScene<GameScene>(Scenes.GAME_SCENE);
            foreach (ICardContainer cardContainer in gameScene.CardContainers) {
                if(cardContainer.IsCardsBeAdded(cardsToMove)) {
                    gameScene.UndoSection.AddMove();
                    cardContainer.AddToStack(cardsToMove);
                    foreach (Card card in cardsToMove) {
                        _pickedCardsList.Remove(card);
                    }
                    break;
                }
            }
            
        }
    }
    public void AddCard(Card card) {
        _pickedCardsList.Add(card);
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
    public int Width {
         get {
             if(_pickedCardsList.Count > 0) {
                return _pickedCardsList[^1].Width;
            } else {
                return _pickedCardsPlace.Width;
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
    }

}
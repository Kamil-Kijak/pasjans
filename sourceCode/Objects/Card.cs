
public class Card : DrawableObject
{
    private bool _showed;
    private string _symbol;
    private string _number;
    private ConsoleColor _cardColor;
    public Card(string number, string symbol, bool showed, ConsoleColor cardColor = ConsoleColor.White) :
     base(string.Format(Content.GetTextObject(Objects.CARD_BODY), number.PadRight(2, ' '), symbol), cardColor, ConsoleColor.Black)
    {
        _cardColor = cardColor;
        Showed = showed;
        _number = number;
        _symbol = symbol;
    }
    public bool Showed {
        set {
            _showed = value;
            if(_showed) {
                _foregroundColor = _cardColor;
                Lines = string.Format(Content.GetTextObject(Objects.CARD_BODY), _number.PadRight(2, ' '), _symbol);
            } else {
                _foregroundColor = ConsoleColor.White;
                Lines = Content.GetTextObject(Objects.CARD_BACK);
            }
        }
    }
}
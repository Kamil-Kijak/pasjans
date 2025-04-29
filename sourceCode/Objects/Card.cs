
public class Card : DrawableObject
{
    private bool _showed;
    private char _character;
    private string _symbol;
    private ConsoleColor _cardColor;
    private DrawableObject _pattern;
    public Card(string symbol, char character, bool showed) :
     base(string.Format(Content.GetTextObject(Objects.CARD_BODY), symbol.PadRight(2, ' '), character), ConsoleColor.Black, ConsoleColor.Black)
    {
        if(character == '♥' || character == '♦') {
            _cardColor = ConsoleColor.Red;
        } else {
            _cardColor = ConsoleColor.White;
        }
        _symbol = symbol;
        _character = character;
        Showed = showed;
        _pattern = new (string.Format(Content.GetCardPattern(symbol), character.ToString().PadRight(2, ' ')), _cardColor, ConsoleColor.Black);
        ForegroundColor = _cardColor;
    }
    public override void Draw(Vector position)
    {
        base.Draw(position);
        _pattern.Draw(new Vector(position.X + 3, position.Y + 3));
    }
    public bool Showed {
        set {
            _showed = value;
            if(_showed) {
                _foregroundColor = _cardColor;
                Lines = string.Format(Content.GetTextObject(Objects.CARD_BODY), _symbol.PadRight(2, ' '), _character);
            } else {
                _foregroundColor = ConsoleColor.White;
                Lines = Content.GetTextObject(Objects.CARD_BACK);
            }
        }
    }
    public new ConsoleColor ForegroundColor {
        get { return _foregroundColor; }
        set {
            _foregroundColor = value;
            _pattern.ForegroundColor = value;
        }
    }
}
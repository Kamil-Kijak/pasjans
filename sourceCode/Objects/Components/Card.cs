
public class Card : DrawableObject, IPanel
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
        _pattern = new (string.Format(Content.GetCardPattern(symbol), character.ToString().PadRight(2, ' ')), _cardColor, ConsoleColor.Black);
        _symbol = symbol;
        _character = character;
        Showed = showed;
    }
    public override void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        base.Draw(position, alignX, alignY);
        if(_showed)  {
            _pattern.Draw(new Vector(position.X + 3, position.Y + 3), alignX, alignY);
        }
    }
    public Card Copy() {
        return new Card(_symbol, _character, _showed);
    }

    public void ActionPerformed()
    {
        
    }

    public char Character {
        get {return _character;}
    }
    public string Symbol {
        get {return _symbol;}
    }
    public ConsoleColor CardColor {
        get {return _cardColor;}
    }
    public bool Showed {
        get {return _showed;}
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
    public override ConsoleColor ForegroundColor {
        get { return _foregroundColor; }
        set {
            _foregroundColor = value;
            _pattern.ForegroundColor = value;
        }
    }
    public override ConsoleColor BackgroundColor {
        get { return _backgroundColor; }
        set {
            _backgroundColor = value;
            _pattern.BackgroundColor = value;
        }
    }
}
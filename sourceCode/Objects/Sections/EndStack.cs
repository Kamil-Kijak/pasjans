

public class EndStack : IPanel {
    private DrawableObject _cardBody;
    private DrawableObject _symbol;
    public EndStack(Objects cardSymbol) {
        _cardBody = new(string.Format(Content.GetTextObject(Objects.CARD_BODY), "  ", " "), ConsoleColor.DarkGray, ConsoleColor.Black);
        _symbol = new(Content.GetTextObject(cardSymbol), ConsoleColor.DarkGray, ConsoleColor.Black);
    }


    public void ActionPerformed()
    {
        
    }

    public void Draw(Vector position)
    {
        _cardBody.Draw(position);
        position.X += 3;
        position.Y += 3;
        _symbol.Draw(position);
    }

    public void Draw(Vector position, AlignX alignX, AlignY alignY)
    {
        Draw(position);
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


public class UndoSection : IPanel
{
    private Text _movesText;
    private DrawableObject _box;
    private Text _undoText;
    private StateObject[] _stateObjects;
    private int _moves;
    private int _undoMoves;
    public UndoSection(GameScene gameScene) {
        _box = DrawManager.CreateBox(17, 5);
        _undoText = new("brak cofania");
        _movesText = new("Ruchy: 0");
        _moves = 0;
        _undoMoves = 0;
        _stateObjects = new StateObject[13];
        for (int i = 0;i<7;i++) {
            _stateObjects[i] = gameScene.CardColumns[i];
        }
        _stateObjects[7] = gameScene.CardStack;
        _stateObjects[8] = gameScene.PickedCards;
        _stateObjects[9] = gameScene.EndStacksDict[EndStacks.HEART];
        _stateObjects[10] = gameScene.EndStacksDict[EndStacks.DIAMOND];
        _stateObjects[11] = gameScene.EndStacksDict[EndStacks.SPADE];
        _stateObjects[12] = gameScene.EndStacksDict[EndStacks.TREFL];
    }
    public void ActionPerformed()
    {
        if(_undoMoves != 0) {
            LoadState();
        }
    }

    public void Draw(Vector position, AlignX alignX = AlignX.LEFT, AlignY alignY = AlignY.TOP)
    {
        if(_undoMoves != 0) {
            _undoText.Lines = ["cofnij ruch"];
        } else {
            _undoText.Lines = ["brak cofania"];
        }
        _movesText.Draw(new Vector(51, 1), AlignX.CENTER, AlignY.TOP);
        if(_undoMoves != 0) {
            position.Y+= 4;
            _box.Draw(position, alignX, alignY);
            position.X += _box.Width / 2;
            position.Y += _box.Height / 2;
            _undoText.Draw(position, AlignX.CENTER, AlignY.CENTER);
        }
    }
    public void AddMove() {
        Moves++;
        if(_undoMoves < 3) {
            _undoMoves++;
        }
        foreach (StateObject obj in _stateObjects) {
            obj.SaveState();
        }
    }
    private void LoadState() {
        _undoMoves--;
        Moves--;
        foreach (StateObject obj in _stateObjects) {
            obj.LoadState();
        }
    }
    private int Moves {
        get{
            return _moves;
        }
        set{
            _moves = value;
            _movesText.Lines = [string.Format("Ruchy: {0}", _moves)];
        }
    }
    public ConsoleColor ForegroundColor {
         get {
            return _box.ForegroundColor;
         }
         set {
            _box.ForegroundColor = value;
            _undoText.ForegroundColor = value;
         }
    }
    public ConsoleColor BackgroundColor {
          get {
            return _box.BackgroundColor;
         }
         set {
            _box.BackgroundColor = value;
            _undoText.BackgroundColor = value;
         }
    }
    public int Width {
         get {
            return _box.Width;
         }
         set {
            _box.Width = value;
         }
    }
    public int Height {
        get {
            return _box.Height;
        }
        set {
            _box.Height = value;
        }
    }
}
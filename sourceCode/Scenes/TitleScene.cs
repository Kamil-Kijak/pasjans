
public class TitleScene : BaseScene {
    private Text _authorText;
    private DrawableObject _title;
    private SelectPanel _gameOptionSelect;
    private DrawableObject _gameOptionSelectBox;

    public TitleScene() {
        _authorText = new(["stworzony przez", " ", "Kamila Kijaka"]);
        _title = new (Content.GetTextObject(Objects.TITLE));
        _gameOptionSelect = new([
            new Text("--->START<---"), new Text("--->RANKING<---"), new Text("--->WYJŚCIE<---")
        ], ConsoleColor.Red);
        _gameOptionSelectBox = DrawManager.CreateBox(21, 10);
    }

    protected override void DrawComponets()
    {
        base.DrawComponets();
        _title.Draw(new Vector(Console.WindowWidth / 2, 0), AlignX.CENTER, AlignY.TOP);
        _authorText.Draw(new Vector(Console.WindowWidth / 2, 7), AlignX.CENTER, AlignY.TOP);
        _gameOptionSelectBox.Draw(new Vector(Console.WindowWidth / 2, 11), AlignX.CENTER, AlignY.TOP);
        _gameOptionSelect.Draw(new Vector(Console.WindowWidth / 2, 13), 1, SelectPanel.Direction.VERTICALY, AlignX.CENTER);

    }
    public override void Update()
    {
        base.Update();
        SelectPanel.ChooseState chooseState;
        while(true) {
            chooseState = _gameOptionSelect.Listen();
            if(chooseState != SelectPanel.ChooseState.STILL) {
                if(chooseState == SelectPanel.ChooseState.CHOOSEN) {
                    switch(_gameOptionSelect.Index) {
                        case 0:
                            // start game
                        break;
                        case 1:
                            // ranking
                        break;
                        case 2:
                        Console.Clear();
                        return;
                    }
                }
                base.Update();
            }
        }
    }
}
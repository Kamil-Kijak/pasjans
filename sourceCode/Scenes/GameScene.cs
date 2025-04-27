
public class GameScene : BaseScene {
    private Difficulty _difficulty;
    private Card _object;

    public GameScene() {
            _object = new Card("10", "♥", false, ConsoleColor.Red);
    }

    protected override void DrawComponets()
    {
        base.DrawComponets();
        _object.Draw(new Vector(10, 10));

    }
    public override void Update()
    {
        base.Update();
        if(Content.GetScene(Scenes.TITLE_SCENE) is TitleScene titleScene) {
            _difficulty = titleScene.SelectedDifficulty;
        }
        while(true) {

        }
    }
}
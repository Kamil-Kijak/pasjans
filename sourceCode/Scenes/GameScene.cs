
public class GameScene : BaseScene {
    private Difficulty _difficulty;

    public GameScene() {
        
    }

    protected override void DrawComponets()
    {
        

    }
    public override void Update()
    {
        base.Update();
        _difficulty = Content.GetScene(Scenes.TITLE_SCENE).SelectedDifficulty;
    }
}
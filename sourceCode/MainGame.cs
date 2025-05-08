

internal class MainGame
{
    private static void Main(string[] args)
    {
        
        Console.Title = "Pasjans by Kamil Kijak";
        if(!Path.Exists(Content.AppPath)) {
            Directory.CreateDirectory(Content.AppPath);
        }
        
        Content.SetScene(Scenes.TITLE_SCENE, new TitleScene());
        Content.SetScene(Scenes.GAME_SCENE, new GameScene());
        Content.SetScene(Scenes.WIN_SCENE, new WinScene());
        
        Content.AddSceneToQueue(Scenes.TITLE_SCENE);
        while(Content.ScenesToLoadQueue.Count > 0) {
            Content.ScenesToLoadQueue[0].SceneActive = true;
            Content.ScenesToLoadQueue.RemoveAt(0);
        }
        Console.Clear();
    }
}
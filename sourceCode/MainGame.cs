

internal class MainGame
{
    private static void Main(string[] args)
    {
        Console.Title = "Pasjans by Kamil Kijak";
        Console.CursorVisible = false;
        if(!Path.Exists(LeaderBoardManager.AppPath)) {
            Directory.CreateDirectory(LeaderBoardManager.AppPath);
        }
        
        ContentManager.SetScene(Scenes.TITLE_SCENE, new TitleScene());
        ContentManager.SetScene(Scenes.GAME_SCENE, new GameScene());
        ContentManager.SetScene(Scenes.WIN_SCENE, new WinScene());
        
        ContentManager.AddSceneToQueue(Scenes.TITLE_SCENE);
        while(ContentManager.ScenesToLoadQueue.Count > 0) {
            ContentManager.ScenesToLoadQueue[0].SceneActive = true;
            ContentManager.ScenesToLoadQueue.RemoveAt(0);
        }
        Console.Clear();
    }
}
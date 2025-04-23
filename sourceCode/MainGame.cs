

internal class MainGame
{
    private static void Main(string[] args)
    {
        // ustawienia początkowe konsoli
        Console.Title = "Pasjans by Kamil Kijak";
        if(!Path.Exists(Content.AppPath)) {
            Directory.CreateDirectory(Content.AppPath);
        }
        // dodawanie scen
        Content.SetScene(Scenes.TITLE_SCENE, new TitleScene());
        Content.SetScene(Scenes.GAME_SCENE, new GameScene());
        Content.SetScene(Scenes.WIN_SCENE, new WinScene());
        Content.SetScene(Scenes.LOSE_SCENE, new LoseScene());
        
        Content.GetScene(Scenes.TITLE_SCENE).Update();
        
    }
}
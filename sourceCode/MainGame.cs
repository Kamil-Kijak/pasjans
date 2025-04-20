

internal class MainGame
{
    private static void Main(string[] args)
    {
        // ustawienia początkowe konsoli
        Console.Title = "Pasjans by Kamil Kijak";
        
            Console.Clear();
            DrawManager.DrawBackground(ConsoleColor.Black);
            
            Console.ReadKey();
    }
}
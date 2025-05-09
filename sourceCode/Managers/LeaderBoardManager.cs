
using System.Text.Json;

public static class LeaderBoardManager {
    private static readonly string _appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pasjans");
    public static string AppPath {
        get {return _appPath;}
    }
    public static string[] LoadLeaderBoard(int limit = 26) {
        if(!File.Exists(Path.Combine(AppPath, "leaderboard.json"))) {
            return [];
        }
        string leaderboardJson = File.ReadAllText(Path.Combine(AppPath, "leaderboard.json"));
        List<ScoreObject>? leaderBoard = JsonSerializer.Deserialize<List<ScoreObject>>(leaderboardJson);
        if(leaderBoard != null) {
            for (int i = 0; i < leaderBoard.Count; i++) {
                if(i >= limit - 1) {
                    leaderBoard.RemoveAt(i);
                }
            }
            leaderBoard.Sort(new ScoreComparator());
            string[] rows = new string[leaderBoard.Count];
            for (int i = 0; i < leaderBoard.Count; i++) {
                rows[i] = new(string.Format("#{0}    data:{1}    ruchy:{2}", i + 1, leaderBoard[i].DateTime, leaderBoard[i].Score));
            }
            return rows;
        } else {
            return [];
        }
    }
    public static void AddNewLeaderBoardScore(ScoreObject score) {
        if(!File.Exists(Path.Combine(AppPath, "leaderboard.json"))) {
            File.WriteAllLines(Path.Combine(AppPath, "leaderboard.json"), ["[]"]);
        }
        string leaderboard = File.ReadAllText(Path.Combine(AppPath, "leaderboard.json"));
        List<ScoreObject>? list = JsonSerializer.Deserialize<List<ScoreObject>>(leaderboard);
        if(list != null) {
            list?.Add(score);
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(Path.Combine(AppPath, "leaderboard.json"), jsonString);
        }
    }
}
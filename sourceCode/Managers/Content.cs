

using System.Text.Json;

public class Content {
    private static readonly string _appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pasjans");
    private static Dictionary<Objects, string> _textData = new()
        {
            {Objects.TITLE,
@"+----------------------------------------------------+
|███████    █     ██████    █     █     █    █ ██████|
|█     █   █ █    █         █    █ █    ██   █ █     |
|███████  █   █   ██████    █   █   █   █ █  █ ██████|
|█       ███████       █ █ ██  ███████  █  █ █      █|
|█      █       █ ██████  █   █       █ █   ██ ██████|
+----------------------------------------------------+"},
            {Objects.WINTITLE,
@"+-------------------------------------------------------------+
| █        █ █     █ ███████ █████     █     █    █     █     |
| █   ██   █  █   █  █       █   █    █ █    ██   █    █ █    |
| █   ██   █   █ █   █   ███ █████   █   █   █ █  █   █   █   |
|  █ █  █ █     █    █     █ █ █    ███████  █  █ █  ███████  |
|   █    █      █    ███████ █  █  █       █ █   ██ █       █ |
+-------------------------------------------------------------+"},
            {Objects.CARD_BODY,
@"+-------------+
|  {1}          |
|  {0}         |
|             |
|             |
|             |
|             |
|             |
|          {0} |
|          {1}  |
+-------------+"},
        {
            Objects.CARD_BACK,
@"+-------------+
|#  #  #  #  #|
| #  #  #  #  |
|  #  #  #  # |
|#  #  #  #  #|
| #  #  #  #  |
|  #  #  #  # |
|#  #  #  #  #|
| #  #  #  #  |
|  #  #  #  # |
+-------------+"
        },
        {Objects.HEART,
@"  ██ ██
 ███████
  █████
   ███  
    █"},
    {Objects.DIAMOND,
@"    █
   ███
  █████
   ███  
    █"},
 {Objects.SPADE, 
@"    █ 
  █████
 ███████
 ███████
    █"
 },
 {Objects.TREFL,
@"   ███
   ███
 ███████
 ███████
    █  
"}
        };
    private static Dictionary<string, string> _cardPatterns = new(){
        {"A",
@"    █
   █ █
  █████
 █     █"},
        {"K", 
@"
█       █
██  █  ██
█████████
          "},
          {"Q",
@"          
 ██    ██
 ███  ███
 ████████"},
          {"J",
@"      █
  ███  █
 ███████
█████████"},
        {"2",
@"    {0}



    {0}"},
{"3",
@"    {0}

    {0}

    {0}"},
    {"4", 
@" {0}   {0}

    
 {0}   {0}"},
{"5",
@" {0}   {0}

    {0}

 {0}   {0}
"},
{"6",
 @" {0}   {0}

 {0}   {0}

 {0}   {0}
 
 "},
 {"7",
@" {0}   {0}
    {0}
 {0}   {0}
    
 {0}   {0}"},
{"8",
@" {0}   {0}

 {0}   {0}
 {0}   {0}

 {0}   {0}"},
{"9",
 @" {0}   {0}
    {0}
 {0}   {0}
 {0}   {0}

 {0}   {0}"},
 {"10",
 @" {0}   {0}
    {0}
 {0}   {0}
 {0}   {0}
    {0}
 {0}   {0}"}
    };
    private static Dictionary<Scenes, BaseScene> _scenes =  new();
    private static List<BaseScene> _scenesToLoadQueue = new();

    public static string GetTextObject(Objects value) {
        return _textData[value];
    }
    public static string GetCardPattern(string pattern) {
        return _cardPatterns[pattern];
    }
    public static BaseScene GetScene(Scenes value) {
        return _scenes[value];
    }
    public static T GetScene<T>(Scenes value) {
        if(_scenes[value] is T scene) {
            return scene;
        } else {
            throw new Exception("Failed to parse a scene");
        }
    }
    public static void SetScene(Scenes key, BaseScene value) {
        if(_scenes.ContainsKey(key)) {
            _scenes.Remove(key);
            _scenes[key] = value;
        } else {
            _scenes.Add(key, value);
        }
    }
    public static void AddSceneToQueue(Scenes scene) {
        _scenesToLoadQueue.Add(GetScene(scene));
    }
    public static string[] LoadLeaderBoard(int limit = 26) {
        if(!File.Exists(Path.Combine(AppPath, "leaderboard.json"))) {
            File.WriteAllLines(Path.Combine(AppPath, "leaderboard.json"), ["[]"]);
        } else {
            string leaderboard = File.ReadAllText(Path.Combine(AppPath, "leaderboard.json"));
            List<ScoreObject>? list = JsonSerializer.Deserialize<List<ScoreObject>>(leaderboard);
            if(list != null) {
                for (int i = 0; i < list.Count; i++) {
                    if(i >= limit - 1) {
                        list.RemoveAt(i);
                    }
                }
                list.Sort(new ScoreComparator());
                string[] rows = new string[list.Count];
                for (int i = 0; i < list.Count; i++) {
                    rows[i] = new(string.Format("#{0}    data:{1}    ruchy:{2}", i + 1, list[i].DateTime, list[i].Score));
                }
                return rows;
            }
        }
        return [];
    }
    public static void AddNewLeaderBoardScore(ScoreObject score) {
        if(!File.Exists(Path.Combine(AppPath, "leaderboard.json"))) {
            File.WriteAllLines(Path.Combine(AppPath, "leaderboard.json"), ["[]"]);
        }
        string leaderboard = File.ReadAllText(Path.Combine(AppPath, "leaderboard.json"));
        List<ScoreObject>? list = JsonSerializer.Deserialize<List<ScoreObject>>(leaderboard);
        list?.Add(score);
        if(list != null) {
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(Path.Combine(AppPath, "leaderboard.json"), jsonString);
        }
    }
    public static List<BaseScene> ScenesToLoadQueue {
        get {return _scenesToLoadQueue;}
    }
    public static string AppPath {
        get {return _appPath;}
    } 

}
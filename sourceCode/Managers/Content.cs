

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
        _scenes.Add(key, value);
    }
    public static string AppPath {
        get {return _appPath;}
    } 

}
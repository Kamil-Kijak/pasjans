

public class ContentManager {
    private static readonly Dictionary<Objects, string> _textData = new()
        {
            {Objects.TITLE,
@"+----------------------------------------------------+
|███████    █     ██████    █     █     █    █ ██████|
|█     █   █ █    █         █    █ █    ██   █ █     |
|███████  █   █   ██████    █   █   █   █ █  █ ██████|
|█       ███████       █ █ ██  ███████  █  █ █      █|
|█      █       █ ██████  █   █       █ █   ██ ██████|
+----------------------------------------------------+"},
            {Objects.WIN_TITLE,
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
    private static readonly Dictionary<string, string> _cardPatterns = new(){
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
    private static readonly Dictionary<Scenes, BaseScene> _scenes =  new();
    private static readonly List<BaseScene> _scenesToLoadQueue = [];

    public static DrawableObject CreateBox(int width, int heigth, ConsoleColor foregroundColor = ConsoleColor.White) {
        string stringObject = "";
        stringObject += '+';
        for (int i = 0; i < width - 2; i++) {
            stringObject += '-';
        }
        stringObject += '+';
        stringObject += '\n';
        for (int i = 0; i < heigth - 2; i++)
        {
            stringObject += '|';
            for (int j = 0; j < width - 2; j++) {
                stringObject += ' ';
            }
            stringObject += '|';
            stringObject += '\n';
        }
        stringObject += '+';
        for (int i = 0; i < width - 2; i++) {
            stringObject += '-';
        }
        stringObject += '+';
        stringObject += '\n';

        DrawableObject box = new (stringObject, foregroundColor);
        return box;
    }

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
            throw new InvalidCastException("Invalid scene cast");
        }
    }
    public static void SetScene(Scenes key, BaseScene value) {
        if(!_scenes.TryAdd(key, value)) {
            _scenes[key] = value;
        }
    }
    public static void AddSceneToQueue(Scenes scene) {
        _scenesToLoadQueue.Add(GetScene(scene));
    }
    public static List<BaseScene> ScenesToLoadQueue {
        get {return _scenesToLoadQueue;}
    }

}
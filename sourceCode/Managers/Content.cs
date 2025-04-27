

public class Content {
    private static readonly string _appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Pasjans");
    private static Dictionary<Objects, string> _textData = new()
        {
            {Objects.TITLE,
@"+----------------------------------------------------+
|#######    #     ######    #     #     #    # ######|
|#     #   # #    #         #    # #    ##   # #     |
|#######  #   #   ######    #   #   #   # #  # ######|
|#       #######       # # ##  #######  #  # #      #|
|#      #       # ######  #   #       # #   ## ######|
+----------------------------------------------------+"},
            {Objects.CARD_BODY,
@"+-----------+
|  {1}        |
|  {0}       |
|           |
|           |
|           |
|           |
|       {0}  |
|        {1}  |
+-----------+"},
        {
            Objects.CARD_BACK,
@"+-----------+
|#  #  #  # |
| #  #  #  #|
|  #  #  #  |
|#  #  #  # |
| #  #  #  #|
|  #  #  #  |
|#  #  #  # |
| #  #  #  #|
+-----------+"
        }
        };
    private static Dictionary<Scenes, BaseScene> _scenes =  new();

    public static string GetTextObject(Objects value) {
        return _textData[value];
    }
    public static BaseScene GetScene(Scenes value) {
        return _scenes[value];
    }
    public static void SetScene(Scenes key, BaseScene value) {
        _scenes.Add(key, value);
    }
    public static string AppPath {
        get {return _appPath;}
    } 

}
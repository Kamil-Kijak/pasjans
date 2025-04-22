

public class Content {
    private static Dictionary<Objects, string> _objects = new Dictionary<Objects, string>()
        {
            {Objects.TITLE,
@"+----------------------------------------------------+
|#######    #     ######    #     #     #    # ######|
|#     #   # #    #         #    # #    ##   # #     |
|#######  #   #   ######    #   #   #   # #  # ######|
|#       #######       # # ##  #######  #  # #      #|
|#      #       # ######  #   #       # #   ## ######|
+----------------------------------------------------+"}
        };

    public static string GetDrawableObject(Objects value) {
        return _objects[value];
    }
}
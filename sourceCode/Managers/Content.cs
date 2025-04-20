

public class Content {
    private static DrawableObject[] _objects = {
        new(
          
@"+----------------------------------------------------+
|#######    #     ######    #     #     #    # ######|
|#     #   # #    #         #    # #    ##   # #     |
|#######  #   #   ######    #   #   #   # #  # ######|
|#       #######       # # ##  #######  #  # #      #|
|#      #       # ######  #   #       # #   ## ######|
+----------------------------------------------------+"
        )
    };
    public static DrawableObject GetDrawableObject(Objects value) {
        return _objects[(int)value];
    }
}
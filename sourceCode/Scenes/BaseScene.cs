
public abstract class BaseScene {

    protected virtual void DrawComponets() {
        Console.Clear();
    }
    public virtual void Update() {
        DrawComponets();
    }
}

public abstract class BaseScene {

    protected virtual void DrawComponets() {
        Console.Clear();
    }
    public virtual void Update() {
        DrawComponets();
    }
    public void LoadScene(Scenes? scene) {
        if(scene != null)
            Content.GetScene((Scenes)scene).Update();
    }
}
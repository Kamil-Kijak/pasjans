
public abstract class BaseScene {
    protected bool _sceneActive = false;
    public virtual void DrawComponets() {
        Console.Clear();
    }
    public virtual void Update() {
        DrawComponets();
    }
    public bool SceneActive {
        get { return _sceneActive; }
        set {
            _sceneActive = value; 
            if(_sceneActive)
                Update();
        }
    }
}
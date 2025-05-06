
public abstract class StateObject {
    protected StateManager _stateManager;
    private List<Card> _actualState;
    public StateObject(int numberOfStates) {
        _stateManager = new(numberOfStates);
        _actualState = new();
    }
    public virtual void SaveState() {
        _stateManager.SaveState(_actualState);
    }
    public virtual void LoadState() {
        _actualState.Clear();
        _actualState.AddRange(_stateManager.LoadPrevirousState());
    }
    protected List<Card> ActualState {
        set{
            _actualState = value;
        }
    }
}
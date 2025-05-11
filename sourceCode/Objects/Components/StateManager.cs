
public class StateManager {

    private List<Card>[] _states;
    public StateManager(int numberOfStates) {
        _states = new List<Card>[numberOfStates];
    }
    public void SaveState(List<Card> newState) {
        for (int i = _states.Length - 1; i > 0; i--) {
                (_states[i - 1], _states[i]) = (_states[i], _states[i - 1]);
        }
        List<Card> newStateCopy = new();
        foreach (Card card in newState){
            newStateCopy.Add(card.Copy());
        }
        _states[0] = newStateCopy;
    }
    public List<Card> LoadPrevirousState() {
        List<Card> list = _states[0].ToList();
        for (int i = 0; i < _states.Length - 1; i++) {
                (_states[i], _states[i + 1]) = (_states[i + 1], _states[i]);
        }
        return list;
    }
}
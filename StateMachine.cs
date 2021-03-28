public class StateMachine<T> where T: Entity
{
    public State<T> CurrentState{get; private set;}

    public StateMachine(State<T> firstState){
        CurrentState = firstState;
    }

    public void SetState(State<T> state){
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
    public void LogicUpdate(){
        CurrentState.LogicUpdate();
    }
    public void PhysicsUpdate(){
        CurrentState.PhysicsUpdate();
    }
    public void HandleInput(){
        CurrentState.HandleInput();
    }
}

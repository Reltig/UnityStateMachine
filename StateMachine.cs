public class StateMachine<T> where T: Entity
{
    public T Entity{get; private set;}
    public IState<T> CurrentState{get; private set;}

    public StateMachine(T entity, IState<T> firstState){
        Entity = entity;
        CurrentState = firstState;
    }

    public void SetState(IState<T> state){
        CurrentState.Exit(Entity);
        CurrentState = state;
        CurrentState.Enter(Entity);
    }
    public void LogicUpdate(){
        CurrentState.LogicUpdate(Entity);
    }
    public void PhysicsUpdate(){
        CurrentState.PhysicsUpdate(Entity);
    }
    public void HandleInput(){
        CurrentState.HandleInput(Entity);
    }
}

using UnityEngine;

public abstract class State<T> where T: Entity{
    protected T entity;
    public State(T entity){
        this.entity = entity;
    }
    public virtual void Enter(){}
    public virtual void LogicUpdate(){}
    public virtual void PhysicsUpdate(){}
    public virtual void HandleInput(){}
    public virtual void Exit(){}
}
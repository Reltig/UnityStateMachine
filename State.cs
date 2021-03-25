using UnityEngine;

public abstract class IState<T> where T: Entity{
    public virtual void Enter(T entity){}
    public virtual void LogicUpdate(T entity){}
    public virtual void PhysicsUpdate(T entity){}
    public virtual void HandleInput(T entity){}
    public virtual void Exit(T entity){}
}
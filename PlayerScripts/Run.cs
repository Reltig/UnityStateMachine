using UnityEngine;

public class Run : IState<Player>
{
    private float direction;
    public Run(){
        direction = 0;
    }
    public Run(float direction){
        this.direction = direction;
    }
    public override void Enter(Player entity)
    {
        base.Enter(entity);
        entity.Animation.Play("run");
        Debug.Log("run");
    }

    public override void Exit(Player entity)
    {
        base.Exit(entity);
        entity.Animation.Stop("run");
    }

    public override void HandleInput(Player entity)
    {
        base.HandleInput(entity);
        direction = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate(Player entity)
    {
        base.LogicUpdate(entity);
        if(entity.RigidBody.velocity.x == 0){
            //entity.StateMachine.SetState(new Idle());
        }
        Debug.Log(entity.RigidBody.velocity.x==0);
    }

    public override void PhysicsUpdate(Player entity)
    {
        base.PhysicsUpdate(entity);
        entity.Move(direction);
    }
}
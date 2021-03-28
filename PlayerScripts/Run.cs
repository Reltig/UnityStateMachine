using UnityEngine;

public class Run : State<Player>
{
    private float direction;

    public Run(Player entity, float direction) : base(entity){
        this.direction = direction;
    }

    public override void Enter()
    {
        base.Enter();
        entity.StartAnimation("run");
        Debug.Log("run");
    }

    public override void Exit()
    {
        base.Exit();
        entity.StopAnimation("run");
    }

    public override void HandleInput()
    {
        base.HandleInput();
        direction = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(entity.GetSpeed().x == 0){
            entity.StateMachine.SetState(new Idle(entity));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        entity.Move(direction);
    }

}
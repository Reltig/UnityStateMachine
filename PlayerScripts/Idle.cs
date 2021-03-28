using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State<Player>
{
    private float direction;

    public Idle(Player entity) : base(entity){
        direction = 0;
    }

    public override void Enter()
    {
        base.Enter();
        entity.StartAnimation("idle");
        Debug.Log("idle");
    }

    public override void Exit()
    {
        base.Exit();
        entity.StopAnimation("idle");
    }

    public override void HandleInput()
    {
        base.HandleInput();
        direction = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(direction != 0){
            entity.Move(direction);
            entity.StateMachine.SetState(new Run(entity, direction));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

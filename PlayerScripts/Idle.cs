using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState<Player>
{
    private float direction = 0;
    public override void Enter(Player entity)
    {
        base.Enter(entity);
        entity.Animation.Play("idle");
        Debug.Log("idle");
    }

    public override void Exit(Player entity)
    {
        base.Exit(entity);
        entity.Animation.Stop("idle");
    }

    public override void HandleInput(Player entity)
    {
        base.HandleInput(entity);
        direction = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate(Player entity)
    {
        base.LogicUpdate(entity);
        if(direction != 0){
            entity.StateMachine.SetState(new Run(direction));
        }
    }

    public override void PhysicsUpdate(Player entity)
    {
        base.PhysicsUpdate(entity);
    }
}

using UnityEngine;
using System;

public class Player : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int health;

    public Rigidbody2D RigidBody{get; private set;}
    public Transform Transform{get; private set;}
    public Animation Animation{get; private set;}
    public StateMachine<Player> StateMachine{get; private set;}

    ~Player(){
        Debug.Log("oh shi//");
    }


    void Awake(){
        RigidBody = GetComponent<Rigidbody2D>();
        Transform = GetComponent<Transform>();
        Animation = GetComponent<Animation>();
    }

    void Start()
    {
        StateMachine = new StateMachine<Player>(this, new Idle());
    }
    void Update()
    {
        StateMachine.HandleInput();
        StateMachine.LogicUpdate();
    }

    void FixedUpdate(){
        StateMachine.PhysicsUpdate();
    }

    public void Jump(){
        RigidBody.velocity = new Vector2(RigidBody.velocity.x, jumpForce);
    }

    public void Move(float direction){
        //RigidBody.velocity = new Vector2(direction*speed, RigidBody.velocity.y);
        RigidBody.AddForce(new Vector2(direction*speed,0));
        Transform.localScale = new Vector3( Math.Sign(direction) , 1f, 1f);
    }

    public void SetAnimation(String animationName){
        Animation.Play(animationName);
    }
}

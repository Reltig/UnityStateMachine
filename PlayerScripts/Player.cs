using UnityEngine;
using System;

public class Player : Entity
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rigidBody;
    private Transform _transform;
    private Animation _animation;
    public StateMachine<Player> StateMachine{get; private set;}


    void Awake(){
        _rigidBody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _animation = GetComponent<Animation>();
    }

    void Start()
    {
        StateMachine = new StateMachine<Player>(new Idle(this));
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
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpForce);
    }

    public void Move(float direction){
        _rigidBody.velocity = new Vector2(direction*speed, _rigidBody.velocity.y);
        _transform.localScale = new Vector3( Math.Sign(direction) , 1f, 1f);
    }

    public void StartAnimation(String animationName){
        _animation.Play(animationName);
    }
    public void StopAnimation(String animationName){
        _animation.Stop(animationName);
    }
    public Vector2 GetSpeed(){
        return _rigidBody.velocity;
    }
}

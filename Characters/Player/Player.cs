using Godot;
using System;
using System.Text;

public class Player : KinematicBody2D
{
    private Vector2 _motion = new Vector2();
    private AnimatedSprite _run; 
    
    private const int Speed = 750;
    private const int Gravity = 3750;
    private const int JumpSpeed = -1700;
    private static readonly Vector2 up = new Vector2(0, -1);

    public override void _Ready()
    {
        _run = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        Fall(delta);
        Run();
        Jump();
        MoveAndSlide(_motion, up);
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        _run.UpdateAnimation(_motion, IsOnFloor());
    }

//    private void UpdateAnimation()
//    {
//        _run.Update();
//    }

    private void Fall(float delta)
    {
        if (IsOnFloor() || IsOnCeiling())
        {
            _motion.y = 0;
        }
        else
        {
            _motion.y += Gravity * delta;
        }
    }
    
    private void Run()
    {
        if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left"))
        {
            _motion.x = Speed;
        }
        else if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right"))
        {
            _motion.x = Speed * -1;
        }
        else
        {
            _run.Play("idle");
            _motion.x = 0;
        }
    }

    private void Jump()
    {
        if (Input.IsActionPressed("ui_jump") && IsOnFloor())
        {
            _motion.y = JumpSpeed;
        }
    }
}

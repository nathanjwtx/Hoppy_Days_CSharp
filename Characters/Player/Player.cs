using Godot;
using System;
using System.Text;

public class Player : KinematicBody2D
{
    private Vector2 _motion = new Vector2();
    private AnimatedSprite _run; 
    
    private const int Speed = 750;
    private const int Gravity = 3000;
    private const int JumpSpeed = -800;
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

    private void Fall(float delta)
    {
        if (IsOnFloor())
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
            _run.FlipH = false;
            _run.Play("run");
            _motion.x = Speed;
        }
        else if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right"))
        {
            _run.FlipH = true;
            _run.Play("run");
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

using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 _motion = new Vector2();
    private int _speed = 750;
    private AnimatedSprite _run; 

    public override void _Ready()
    {
        _run = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left"))
        {
            _run.FlipH = false;
            _run.Play("run");
            _motion.x = _speed;
        }
        else if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right"))
        {
            _run.FlipH = true;
            _run.Play("run");
            _motion.x = _speed * -1;
        }
        else
        {
            _run.Play("idle");
            _motion.x = 0;
        }

        MoveAndSlide(_motion);
    }
}

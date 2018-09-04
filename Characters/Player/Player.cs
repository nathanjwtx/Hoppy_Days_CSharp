using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 _motion = new Vector2();
    private int _speed = 750;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left"))
        {
            _motion.x = _speed;
        }
        else if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right"))
        {
            _motion.x = _speed * -1;
        }
        else
        {
            _motion.x = 0;
        }

        MoveAndSlide(_motion);
    }
}

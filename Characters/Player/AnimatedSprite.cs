using Godot;
using System;

public class AnimatedSprite : Godot.AnimatedSprite
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public void UpdateAnimation(Vector2 motion, bool onfloor)
    {
        if (motion.y < 0)
        {
            Play("jump");
        }
        else if (motion.y > 0 && !onfloor)
        {
            Play("fall");
        }
        else if (motion.x > 0)
        {
            FlipH = false;
            Play("run");
        }
        else if (motion.x < 0)
        {
            FlipH = true;
            Play("run");
        }
        else
        {
            Play("idle");
        }
    }
}

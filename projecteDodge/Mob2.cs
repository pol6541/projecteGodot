using Godot;
using System;

public class Mob2 : RigidBody2D
{
	
	[Export]
	public int MinSpeed = 200; // Minimum speed range.

	[Export]
	public int MaxSpeed = 300; // Maximum speed range.

	private String[] _mobTypes = {"bolaFoc"};

	static private Random _random = new Random();
	public override void _Ready()
	{
		GetNode<AnimatedSprite>("AnimatedSprite").Animation = _mobTypes[_random.Next(0, _mobTypes.Length)];
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_Visibility_screen_exited()
	{
		QueueFree();
	}
}

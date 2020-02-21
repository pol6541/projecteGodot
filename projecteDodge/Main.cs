using Godot;
using System;

public class Main : Node2D
{

	[Export]
	public PackedScene Mob;

	private int _score;
	private Random _random = new Random();
	
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	private float RandRange(float min, float max)
	{
		return (float)_random.NextDouble() * (max - min) + min;
	}
}

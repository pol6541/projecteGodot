using Godot;
using System;

public class Main : Node2D
{

	[Export]
	public PackedScene Mob;
	
	[Export]
	public PackedScene Mob2;
	
	[Export]
	public PackedScene Moneda;

	private int _score;
	private Random _random = new Random();
	private Vector2 _screenSize;
	
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
	
	private void GameOver()
	{
		GetNode<HUD>("HUD").ShowGameOver();
		GetNode<Timer>("MobTimer").Stop();
		GetNode<Timer>("ScoreTimer").Stop();
		
		
		
	}
	
	public void NewGame()
	{
		_score = 0;
		
		var player = GetNode<Player>("Player");
		var startPosition = GetNode<Position2D>("StartPosition");
		player.Start(startPosition.Position);
		
		GetNode<Timer>("StartTimer").Start();
		
		var hud = GetNode<HUD>("HUD");
		hud.UpdateScore(_score);
		hud.ShowMessage("Get Ready!");
		
		
	}
	
	
	
	private void _on_StartTimer_timeout()
	{
		GetNode<Timer>("MobTimer").Start();
		GetNode<Timer>("ScoreTimer").Start();
	}
	
	
	private void _on_MobTimer_timeout()
	{
		Random rnd = new Random();
		var random = rnd.Next(1,11);
		
		if (_score % 20 == 0 && _score > 0) {
			
			_screenSize = GetViewport().Size;
			
			float x = _screenSize.x;
			float y = _screenSize.y;
			
			float randomx = rnd.Next(10,480);
			float randomy = rnd.Next(10,720);
		
			// Choose a random location on Path2D.
			var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
			mobSpawnLocation.SetOffset(_random.Next());

			// Create a Mob instance and add it to the scene.
			var monedaInstance = (RigidBody2D)Moneda.Instance();
			AddChild(monedaInstance);

			// Set the mob's direction perpendicular to the path direction.
			float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

			// Set the mob's position to a random location.
			monedaInstance.Position = new Vector2(randomx,randomy);

		} 
		
		if (random == 1 || random == 2) {
			// Choose a random location on Path2D.
			var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
			mobSpawnLocation.SetOffset(_random.Next());
		
			// Create a Mob instance and add it to the scene.
			var mobInstance = (RigidBody2D)Mob2.Instance();
			AddChild(mobInstance);
		
			// Set the mob's direction perpendicular to the path direction.
			float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;
		
			// Set the mob's position to a random location.
			mobInstance.Position = mobSpawnLocation.Position;
		
			// Add some randomness to the direction.
			direction += RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
			mobInstance.Rotation = direction;
		
			// Choose the velocity.
			mobInstance.SetLinearVelocity(new Vector2(RandRange(150f, 250f), 0).Rotated(direction));
			
			_score = _score + 2;
			GetNode<HUD>("HUD").UpdateScore(_score);
		} else {
		
		// Choose a random location on Path2D.
		var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
		mobSpawnLocation.SetOffset(_random.Next());
	
		// Create a Mob instance and add it to the scene.
		var mobInstance = (RigidBody2D)Mob.Instance();
		AddChild(mobInstance);
	
		// Set the mob's direction perpendicular to the path direction.
		float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;
	
		// Set the mob's position to a random location.
		mobInstance.Position = mobSpawnLocation.Position;
	
		// Add some randomness to the direction.
		direction += RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		mobInstance.Rotation = direction;
	
		// Choose the velocity.
		mobInstance.SetLinearVelocity(new Vector2(RandRange(150f, 250f), 0).Rotated(direction));
		_score++;
		GetNode<HUD>("HUD").UpdateScore(_score);
		}
	}
	
	
}








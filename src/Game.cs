using System.Timers;
using Esoterica.Content;

namespace Esoterica.Globals;
public static class Game
{
	public static event Action? ProcessTick;
	public static event Action? PhysicsProcessTick;

	public static Casting Casting { get; set; } = new();
	public static Sigils Sigils { get; set; } = new();
	public static Rank Rank { get; set; } = new();

	public static void StartGame()
	{
		var physicsTimer = new System.Timers.Timer();
		physicsTimer.Interval = 1000 / 10; // A Tick is 1000/20 ms or 1/20 seconds
		physicsTimer.AutoReset = true;
		physicsTimer.Elapsed += EventLoop;
		physicsTimer.Start();
	
		var processTimer = new System.Timers.Timer();
		processTimer.Interval = 1000 / 20; 
		processTimer.AutoReset = true;
		processTimer.Elapsed += (s, e) => ProcessTick?.Invoke(); 
		processTimer.Start();
	}

	public static void EventLoop(object? sender, ElapsedEventArgs e)
	{
		PhysicsProcessTick?.Invoke();
		CalculateMagiculeGain();
	}

	public static void CalculateMagiculeGain()
	{
		Player.Magicules += Sigils.SigilMultipliers * Rank.RankBonuses[0]!.Invoke();		
	}
}
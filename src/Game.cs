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
		var timer = new System.Timers.Timer();
		timer.Interval = 1000 / 20; // A Tick is 1000/20 ms or 1/20 seconds
		timer.AutoReset = true;
		timer.Elapsed += EventLoop;
		timer.Start();
	}

	public static void EventLoop(object? sender, ElapsedEventArgs e)
	{
		PhysicsProcessTick?.Invoke();
		Console.WriteLine("Heya");
	}
}
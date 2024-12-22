using System.Diagnostics.CodeAnalysis;
using Esoterica.Globals;
using Esoterica.Types;

namespace Esoterica.Content;

public class Casting
{
	public Queue<ICastables> CastingQueue { get; private set; } = new();
	public int ConcurrentCasts { get; set; } = 0;
	public void CastSpells()
	{
		if (CastingQueue.Count() == 0)
			return;

		var spell = CastingQueue.Peek();
		spell.CastingProgress += 1 * Player.Focus;

		if (spell.CastingProgress >= spell.MaxProgress)
		{
			spell.CastingProgress = 0;

			  spell.OnFinishCasting?.Invoke();

			spell.CastingCount++;

			CastingQueue.Dequeue();
		}
	}

	public Casting()
	{
		Game.PhysicsProcessTick += CastSpells;
	}
}
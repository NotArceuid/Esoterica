// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using Esoterica.Globals;
using Esoterica.Types;

public class Sigils : ISavable
{
	public Sigils()
	{
		Game.PhysicsProcessTick += () => {

		};
	}

	public void BuySigil(int sigilId)
	{

	}

	public struct SigilType: ICastables
	{
		public string SigilName { get; set; }
		public event Action<bool> RequirementsMet;
		public BigDouble CastingProgress { get; set; }
		public BigDouble MaxProgress { get; set; }

	}

	public void OnLoad()
	{

	}
}

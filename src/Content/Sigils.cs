// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using Esoterica.Globals;
using Esoterica.Types;

public class Sigils : ISavable
{
	public List<SigilType> SigilList = [
		new SigilType("Lesser Sigil", () => Player.Magicules >= 10, "100", 100),
		new SigilType("Sigil", () => Player.Magicules >= 1000, "10000", 1000),
		new SigilType("Greater Sigil", () => Player.Magicules >= 100000000, "100000000", 1000000),
	];

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
		public event Func<bool> RequirementsMet;
		public BigDouble CastingProgress { get; set; }
		public BigDouble MaxProgress { get; set; }
		public BigDouble SigilCount { get; set; }
		public string CostText { get; set; }
		public SigilType(string name, Func<bool> requirement, string costText, BigDouble maxProgress)
		{
			SigilName = name;
			RequirementsMet = requirement;
			CostText = costText;
			MaxProgress = maxProgress;
		}

	}

	public void OnLoad()
	{

	}
}

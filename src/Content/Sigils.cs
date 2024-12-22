// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using Esoterica.Globals;
using Esoterica.Pages;
using Esoterica.Types;

public class Sigils : ISavable
{
	public List<SigilType> SigilList = [
		new SigilType
		(
			"Lesser Sigil", 
			() => Player.Magicules >= 10, 
			() => Player.Magicules -= 10,
			"10", 
			100
		),
	];
 
	public Sigils()
	{

	}

	public void BuySigil(int sigilId)
	{
		var currentSigil = SigilList[sigilId];
		var canbuy = currentSigil.RequirementsMet?.Invoke();

		if (canbuy!.Value)
		{
			
		}
	}

	public struct SigilType : ICastables
	{
		public string SigilName { get; set; }
		public Func<bool> RequirementsMet;
		public BigDouble CastingProgress { get; set; }
		public BigDouble MaxProgress { get; set; }
		public string CostText { get; set; }
		public SigilType(string name, Func<bool> requirement, Action onFinishCasting, string costText, BigDouble maxProgress)
		{
			SigilName = name;
			RequirementsMet = requirement;
			OnFinishCasting = onFinishCasting;
			CostText = costText;
			MaxProgress = maxProgress;
		}

		public Action OnFinishCasting { get; set; }
		public BigDouble CastingCount { get; set; }
	}

	public void OnLoad()
	{

	}
}

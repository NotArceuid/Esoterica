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
			() => {},
 			"10", 
			100
		),
		new SigilType
		(
			"Lesser Sigil", 
			() => Player.Magicules >= 10, 
			() => Player.Magicules -= 10,
			() => {},
 			"10", 
			100
		),
	];
 
	public Sigils()
	{

	}

	public void BuySigil(int sigilId)
	{
		Console.WriteLine($"bought + {sigilId}");
		var currentSigil = SigilList[sigilId];
		var canbuy = currentSigil.RequirementsMet?.Invoke();

		if (canbuy!.Value)
		{
			currentSigil.OnRequirementMet?.Invoke();
			Game.Casting.CastingQueue.Enqueue(currentSigil);
		}
	}

	public struct SigilType : ICastables
	{
		public string SigilName { get; set; }
		public Func<bool> RequirementsMet;
		public Action OnRequirementMet;
		public BigDouble CastingProgress { get; set; }
		public BigDouble MaxProgress { get; set; }
		public string CostText { get; set; }
		public SigilType(string name, Func<bool> requirement, Action onRequirementMet, Action onFinishCasting, string costText, BigDouble maxProgress)
		{
			SigilName = name;
			RequirementsMet = requirement;
			OnRequirementMet = onRequirementMet;
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

// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using Esoterica.Globals;
using Esoterica.Pages;
using Esoterica.Types;

public class Sigils : ISavable
{
	public BigDouble SigilMultipliers { get; set; } = BigDouble.Zero;
	public List<SigilType> SigilList = [
		new SigilType
		(
			"Lesser Sigil", 
			() => Player.Magicules >= 100, 
			() => Player.Magicules -= 100,
			() => Game.Sigils.SigilMultipliers += 1,
 			"100", 
			100
		),
		new SigilType
		(
			"Sigil", 
			() => Player.Magicules >= 2500, 
			() => Player.Magicules -= 2500,
			() =>  Game.Sigils.SigilMultipliers += 10,
 			"2500",  
			500
		),
		new SigilType
		(
			"Greater Sigil", 
			() => Player.Magicules >= 10000, 
			() => Player.Magicules -= 10000,
			() =>  Game.Sigils.SigilMultipliers += 25,
 			"10000",  
			1000
		),
	];

	public void BuySigil(int sigilId)
	{
		var currentSigil = SigilList[sigilId];
		var canbuy = currentSigil.RequirementsMet?.Invoke();

		if (canbuy!.Value)
		{
		Console.WriteLine($"bought + {sigilId}");		
			currentSigil.OnRequirementMet?.Invoke();
			Game.Casting.CastingQueue.Enqueue(currentSigil);
		}
	}

	public struct SigilType : ICastables
	{
		public string Name { get; set; }
		public Func<bool> RequirementsMet;
		public Action OnRequirementMet;
		public BigDouble CastingProgress { get; set; }
		public BigDouble MaxProgress { get; set; }
		public string CostText { get; set; }
		public SigilType(string name, Func<bool> requirement, Action onRequirementMet, Action onFinishCasting, string costText, BigDouble maxProgress)
		{
			Name = name;
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

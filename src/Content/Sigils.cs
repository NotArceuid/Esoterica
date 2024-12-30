// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using Esoterica.Globals;
using Esoterica.Pages;
using Esoterica.Types;

public class Sigils : ISavable
{
	public static BigDouble SigilMultipliers => (Player.SigilCount[0] * .025) + (Player.SigilCount[1] * .45) + (Player.SigilCount[2] * 1.5);
	public List<SigilType> SigilList = [
		new SigilType
		(
			"Lesser Sigil",
			() => Player.Magicules >= 10,
			() => Player.Magicules -= 10,
			() =>
			{
				Game.Rank.GiveLevelExp(5);
				Player.SigilCount[0]++;
			},
 			"10 Magiucles",
			100
		),
		new SigilType
		(
			"Sigil",
			() => Player.SigilCount[0] >= 10 && Player.SigilCount[0] - 10 >= 0,
			() => {  },
			() =>
			{
				var sigil = Game.Sigils.SigilList[0]; Player.SigilCount[0] -= 10;
				Game.Rank.GiveLevelExp(75);
				Player.SigilCount[1]++;
			},
 			"10 Lesser Sigils",
			500
		),
		new SigilType
		(
			"Greater Sigil",
			() =>   Player.SigilCount[1] >= 10  && Player.SigilCount[0] - 10 >= 0,
			() =>  {  },
			() =>
			{
				var sigil = Game.Sigils.SigilList[1];  Player.SigilCount[1] -= 10;
				Game.Rank.GiveLevelExp(500);
				Player.SigilCount[2]++;
			},
 			"10 Sigils",
			1000
		),
	];

	public void BuySigil(int sigilId)
	{
		if (Game.Casting.CastingQueue.Count >= Game.Casting.MaxConcurrentCasts)
			return;

		var currentSigil = SigilList[sigilId];
		var newSigil = new SigilType(currentSigil.Name, currentSigil.RequirementsMet, currentSigil.OnRequirementMet, currentSigil.OnFinishCasting, currentSigil.CostText, currentSigil.MaxProgress);
		var canbuy = currentSigil.RequirementsMet?.Invoke();

		if (canbuy!.Value)
		{
			currentSigil.OnRequirementMet?.Invoke();
			Game.Casting.CastingQueue.Enqueue(newSigil);
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
	}

	public void OnLoad()
	{

	}
}

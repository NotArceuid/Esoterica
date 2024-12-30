// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using System.Reflection.Metadata.Ecma335;
using Esoterica.Globals;
using Esoterica.Types;
namespace Esoterica.Content;
public class Rank : ISavable
{
	public BigDouble CurrentLevelProgress { get; set; }
	// public event Action OnLevelUp;

	public int Tier { get; set; }
	public long CurrentTierProgress { get; set; }
	// public event Action<BigDouble> GetRequiredTierProgress;
	// public event Action OnTierUp;
	public struct RankType
	{
		public string RankName { get; set; }
		public ResponseAction<bool> RankRequirement;
		public ResponseAction<string[]> RequirementText;
		public string[] RankUnlocks;
		public Action OnRankUp;
		public RankType(string name, ResponseAction<bool> rankRequirement, ResponseAction<string[]> requirementText, Action onRankUp, string[] rankUnlocks)
		{
			RankName = name;
			RankRequirement = rankRequirement;
			RequirementText = requirementText;
			OnRankUp = onRankUp;
			RankUnlocks = rankUnlocks;
		}
	}

	public void OnLoad()
	{

	}

	

	public BigDouble GetRequiredLevelProgress()
	{
		var requirement = new BigDouble(17.9 * Player.Level) * new BigDouble(1.12).Pow(Player.Level) ;
		return requirement;
	}

	public void GiveLevelExp(BigDouble amount)
	{
		// Todo: find the meth for it
		var requiredAmount = GetRequiredLevelProgress();
		var leftOverAmount = amount - requiredAmount;
		
		CurrentLevelProgress += amount;
	
		if (CurrentLevelProgress >= requiredAmount)
		{
			CurrentLevelProgress = 0;
			Player.Level++;
		}
	}

	public List<RankType> Ranks = [
		new RankType(
			"Uninitiated",
			() => true,
			() => ["none"],
			() => {},
			["Lesser Sigil Autocast", "Crystals", "New Rank Bonuses", "New Advancements"]
		),
		new RankType(
			"Neophyte",
			() => Player.Magicules >= 100000 && Player.SigilCount[2] >= 1 && Player.Level >= 10,
			() => [$"Magicules ({Player.Magicules.Format()}/100k)", $"Greater Sigils ({Player.SigilCount[2]}/1) "],
			() => Game.Rank.RankBonusTracker[0] = 1,
			[]
		),	
		new RankType(
			"Zelator",
			() => false,
			() => [],
			() => {},
			[]
		)		
	];

	public List<Func<BigDouble>> RankBonuses = new () {
		() => new BigDouble(1+0.25 * (5^Game.Rank.Tier) * Player.Level ) * Game.Rank.RankBonusTracker[0], // magicules bonus
		() => BigDouble.Zero
	}; 

	// if it is not activated, the bonuses will be 0, this negating the effects
	public int[] RankBonusTracker = [1];

	public void GiveRank(int rankId)
	{
		Player.Rank = rankId;
		Ranks[rankId].OnRankUp?.Invoke();
	}
}

// Rank - Specifies the content that is unlocked
// Tier - Determines which Upgrades you're going to get
// Levels - Grant multipliers to your rank

// Ripped straight out of golden dawn's rank system lolv
// 	Neophyte,
// 	Zelator,
// 	Theoricus,
// 	Practicus,
// 	Philosophus,

// 	AdeptusMinor,
// 	AdeptusMajor,
// 	AdeptusExemptus,

// 	MagisterTempli,
// 	Magus,
// 	Ipsissimus,
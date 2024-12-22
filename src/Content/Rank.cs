// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using Esoterica.Types;
namespace Esoterica.Content;
public class Rank : ISavable
{
	public int Level { get; set; } = 1;
	public BigDouble CurrentLevelProgress { get; set; }
	public event Action OnLevelUp;

	public int Tier { get; set; }
	public long CurrentTierProgress { get; set; }
	public event Action<BigDouble> GetRequiredTierProgress;
	public event Action OnTierUp;

	public struct RankType
	{
		public string RankName { get; set; }
		public event Action<bool> RankUpCheck;
		public event Action RankUp;

	}

	public void OnLoad()
	{

	}

	public BigDouble GetRequiredLevelProgress()
	{
		var requirement = new BigDouble(15 * this.Level * 1.12).Pow(this.Level) ;
		return requirement;
	}

	public void GiveLevelExp(BigDouble amount)
	{
		var calculated
		CurrentLevelProgress += amount;
	}
}

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
// Rank - Unlocks contents
// Tier - Unlocks bonus multipliers
// Level - Determines how good is your tier bonus multipliers

using Esoterica.Types;
namespace Esoterica.Content;
public class Rank : ISavable
{
	public long Level { get; set; }
	public long CurrentLevelProgress { get; set; }
	public event Action<BigDouble> GetRequiredLevelProgress;
	public event Action OnLevelUp;

	public long Tier { get; set; }
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
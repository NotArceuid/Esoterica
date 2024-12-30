using Esoterica.Content;
using Esoterica.Types;

namespace Esoterica.Globals;

public static class Player
{
	public static BigDouble Magicules { get; set; } = new BigDouble(10);
	public static BigDouble Focus { get; set; } = new BigDouble(10);
	public static int Rank { get; set; } = 0;
	public static int Level { get; set; } = 1;
	public static BigDouble[] SigilCount { get; set; } = [0, 0, 0];
}
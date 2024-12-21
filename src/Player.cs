using Esoterica.Content;
using Esoterica.Types;

namespace Esoterica.Globals;

public static class Player {
	public static BigDouble Magicules { get; set; }
	public static BigDouble Focus { get; set; }
	public static Rank Rank { get; set; } = new();
}
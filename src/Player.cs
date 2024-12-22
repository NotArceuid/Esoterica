using Esoterica.Content;
using Esoterica.Types;

namespace Esoterica.Globals;

public static class Player {
	public static BigDouble Magicules { get; set; } = new BigDouble(100);
	public static BigDouble Focus { get; set; } = BigDouble.One;
}
namespace Esoterica.Types;

public interface ICastables
{
	public string SigilName { get; set; }
	public BigDouble CastingProgress { get; set; }
	public BigDouble MaxProgress { get; set; }
	public BigDouble CastingCount { get; set; }
	public Action OnFinishCasting { get; set; }
}
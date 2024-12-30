namespace Esoterica.Types;

public interface ICastables
{
	public string Name { get; set; }
	public BigDouble CastingProgress { get; set; }
	public BigDouble MaxProgress { get; set; }
	public Action OnFinishCasting { get; set; } 
}
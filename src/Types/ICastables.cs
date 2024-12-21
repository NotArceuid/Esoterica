namespace Esoterica.Types;

public interface ICastables
{
	public string SigilName { get; set; }
	public event Action<bool> RequirementsMet;
	public BigDouble CastingProgress { get; set; }
	public BigDouble MaxProgress { get; set; }
}
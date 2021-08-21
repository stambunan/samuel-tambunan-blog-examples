namespace Spt.Examples.ExampleServices
{
	public class MathService : IMathService
	{
		public int Add(int a, int b)
		{
			return a + b;
		}
	}

	public interface IMathService
	{
		/// <summary>
		/// Adds two integers together
		/// </summary>
		int Add(int a, int b);
	}
}

namespace BenchmarkAutomapper
{
	public interface IObjectToObjectMapper
	{
		string Name { get; }
		void Initialize();
		void Map();
	}
}
namespace NullFrameworkException
{
	public interface IRunnable
	{
		bool Enabled { get; set; }

		void Setup(params object[] _params);
		void Run(params object[] _params);
	}
}
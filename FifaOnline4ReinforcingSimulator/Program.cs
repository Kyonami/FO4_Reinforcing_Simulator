internal class Program
{

	private static void Main(string[] args)
	{
		Console.Write("Start level : ");
		int start = int.Parse(Console.ReadLine());

		Console.Write("End level : ");
		int end = int.Parse(Console.ReadLine());

		Console.Write("Trying Count : ");
		int tryingCount = int.Parse(Console.ReadLine());

		int totalCount = 0;
		for (int i = 0; i < tryingCount; i++)
		{
			int count = 0;
			int currentLevel = start;

			while (currentLevel < end)
			{
				Console.Write($"{currentLevel} -> ");
				currentLevel = Smith.Reinforce(currentLevel);
				Console.WriteLine($"{currentLevel}, Count : {++count}");
			}

			totalCount += count;
		}

		Console.WriteLine($"Average : {totalCount / tryingCount}");
	}
}
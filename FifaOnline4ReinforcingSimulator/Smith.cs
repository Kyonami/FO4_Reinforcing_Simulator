public static class Smith
{
	const int MAX_LEVEL = 10;
	// 1 -> 2, 2 -> 3, 3 -> 4
	private static readonly int[] successProb = new int[]
	{
		100, 81, 64, 50, 26, 15, 7, 4, 2
	};

	// Key : start level, Value : restore level
	private static readonly Dictionary<int, int[]> restoreProbTable = new Dictionary<int, int[]>
	{
		{ 1, new int[] { 100 } },
		{ 2, new int[] { 100 } },
		{ 3, new int[] { 65, 35 } },
		{ 4, new int[] { 55, 45 } },
		{ 5, new int[] { 35, 40, 25 } },
		{ 6, new int[] { 10, 32, 36, 22 } },
		{ 7, new int[] { 4, 10, 30, 35, 21 } },
		{ 8, new int[] { 2, 4, 10, 28, 35, 21 } },
		{ 9, new int[] { 1, 2, 4, 10, 28, 34, 21 } }
	};

	private static int GetRandomNumber1to100()
	{
		return Random.Shared.Next(100) + 1;
	}
	private static bool IsSuccess(int level, int keyNumber)
	{
		return level < successProb.Length & keyNumber <= successProb[level - 1];
	}
	private static int Restore(int level)
	{
		if (!restoreProbTable.ContainsKey(level))    // 복구 테이블에 데이터 없으면 무조건 1복.
			return 1;

		int[] restoreProb = restoreProbTable[level];
		int keyNumber = GetRandomNumber1to100();
		int anchor = 0;

		for (int i = 0; i < restoreProb.Length; i++)
		{
			anchor += restoreProb[i];

			if (keyNumber <= anchor)
				return i + 1;
		}

		return restoreProb.Length - 1;
	}

	public static int Reinforce(int level)
	{
		if (MAX_LEVEL <= level)
			return MAX_LEVEL;

		if (IsSuccess(level, GetRandomNumber1to100()))
			return level + 1;

		return Restore(level);
	}
}
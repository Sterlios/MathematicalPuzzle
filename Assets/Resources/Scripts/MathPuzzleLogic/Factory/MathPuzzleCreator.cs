using MathPuzzleLogic.Logic;
using System;

namespace MathPuzzleLogic.Factory
{
	public class MathPuzzleCreator
	{
		private static readonly Random _random = new();

		public MathPuzzle Create(int rawCount, int columnCount)
		{
			int goal = CalculateGoal();
			int[,] numbers = CreateArray(goal, rawCount, columnCount);

			numbers = Shuffle(numbers);

			return new MathPuzzle(numbers, goal);
		}

		private int CalculateGoal()
		{
			int minGoal = 4;
			int maxGoal = 9;
			int goalMultiply = 10;

			return _random.Next(minGoal, maxGoal) * goalMultiply;
		}

		private int[,] CreateArray(int goal, int rawCount, int columnCount)
		{
			int[,] numbers = new int[rawCount, columnCount];
			int[] goals = GetGoalsArray(goal, rawCount);

			for (int raw = 0; raw < rawCount; raw++)
				numbers = FillRay(numbers, goals[raw], raw);

			return numbers;
		}

		private int[,] FillRay(int[,] numbers, int goal, int rayIndex)
		{
			for (int j = 0; j < numbers.GetLength(1) - 1; j++)
			{
				numbers[rayIndex, j] = _random.Next(0, goal / 2);
				goal -= numbers[rayIndex, j];
			}

			numbers[rayIndex, numbers.GetLength(1) - 1] = goal;

			return numbers;
		}

		private int[] GetGoalsArray(int goal, int count)
		{
			int[] goals = new int[count];

			for (int i = 0; i < goals.Length; i++)
				goals[i] = goal;

			return goals;
		}

		private int[,] Shuffle(int[,] numbers)
		{
			for (int depth = 0; depth < numbers.GetLength(1); depth++)
			{
				int shiftCount = _random.Next(1, numbers.GetLength(0) * 3);
				ShiftSeveralTimes(numbers, depth, shiftCount);
			}

			return numbers;
		}

		private static void ShiftSeveralTimes(int[,] numbers, int depth, int shiftCount)
		{
			for (int shiftNumber = 0; shiftNumber < shiftCount; shiftNumber++)
				Shift(numbers, depth);
		}

		private static void Shift(int[,] numbers, int depth)
		{
			for (int ray = 0; ray < numbers.GetLength(0) - 1; ray++)
				(numbers[ray, depth], numbers[ray + 1, depth]) = (numbers[ray + 1, depth], numbers[ray, depth]);
		}
	}
}

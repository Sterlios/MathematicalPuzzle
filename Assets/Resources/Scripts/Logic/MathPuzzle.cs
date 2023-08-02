using System;

namespace CookingNumbers
{
	public class MathPuzzle
	{
		private readonly int[,] _numbers;
		private readonly int _goal;

		public event Action<int> Moved;
		public event Action ShiftedUp;
		public event Action ShiftedDown;
		public event Action Resolved;

		public MathPuzzle(int[,] numbers, int goal)
		{
			_numbers = numbers;
			_goal = goal;
			CurrentColumn = 0;
		}

		public int CurrentColumn { get; private set; }

		public int GetValue(int rayIndex, int wheelIndex) =>
			_numbers[rayIndex, wheelIndex];

		public void ShiftUp()
		{
			for (int i = 0; i < _numbers.GetLength(0) - 1; i++)
				(_numbers[i, CurrentColumn], _numbers[i + 1, CurrentColumn]) = 
					(_numbers[i + 1, CurrentColumn], _numbers[i, CurrentColumn]);

			ShiftedUp?.Invoke();
			TryFinish();
		}

		public void ShiftDown()
		{
			for (int i = _numbers.GetLength(0) - 1; i > 0; i--)
				(_numbers[i, CurrentColumn], _numbers[i - 1, CurrentColumn]) = 
					(_numbers[i - 1, CurrentColumn], _numbers[i, CurrentColumn]);

			ShiftedDown?.Invoke();
			TryFinish();
		}

		public void MoveTo(int to)
		{
			CurrentColumn = Math.Clamp(to, 0, _numbers.GetLength(1) - 1);
			Moved?.Invoke(CurrentColumn);
		}

		public void MoveLeft()
		{
			CurrentColumn = CurrentColumn - 1 < 0 ? _numbers.GetLength(1) - 1 : CurrentColumn - 1;
			Moved?.Invoke(CurrentColumn);
		}

		public void MoveRight()
		{
			CurrentColumn = CurrentColumn + 1 > _numbers.GetLength(1) - 1 ? 0 : CurrentColumn + 1;
			Moved?.Invoke(CurrentColumn);
		}

		private void TryFinish()
		{
			for (int i = 0; i < _numbers.GetLength(0); i++)
				if (SumLine(i) != _goal)
					return;

			Resolved?.Invoke();
		}

		private int SumLine(int raw)
		{
			int sum = 0;

			for (int j = 0; j < _numbers.GetLength(1); j++)
				sum += _numbers[raw, j];

			return sum;
		}
	}
}

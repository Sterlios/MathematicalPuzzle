using System;

namespace MathPuzzleLogic.Logic
{
	public class MathPuzzle
	{
		private readonly int[,] _numbers;

		private bool _enabled;

		public event Action<int> Moved;
		public event Action ShiftedUp;
		public event Action ShiftedDown;
		public event Action Resolved;

		public MathPuzzle(int[,] numbers, int goal)
		{
			_numbers = numbers;
			Goal = goal;
			CurrentColumn = 0;
			_enabled = true;
		}

		public int RaysCount => _numbers.GetLength(0);
		public int WheelsCount => _numbers.GetLength(1);
		public int Goal { get; private set; }
		public int CurrentColumn { get; private set; }
		public string SaverKey => $"{RaysCount}:{WheelsCount}";

		public int GetValue(int rayIndex, int wheelIndex) =>
			_numbers[rayIndex, wheelIndex];

		public void ShiftUp()
		{
			if (_enabled)
			{
				for (int i = 0; i < _numbers.GetLength(0) - 1; i++)
					(_numbers[i, CurrentColumn], _numbers[i + 1, CurrentColumn]) =
						(_numbers[i + 1, CurrentColumn], _numbers[i, CurrentColumn]);

				ShiftedUp?.Invoke();
				TryFinish();
			}
		}

		public void ShiftDown()
		{
			if (_enabled)
			{
				for (int i = _numbers.GetLength(0) - 1; i > 0; i--)
					(_numbers[i, CurrentColumn], _numbers[i - 1, CurrentColumn]) =
						(_numbers[i - 1, CurrentColumn], _numbers[i, CurrentColumn]);

				ShiftedDown?.Invoke();
				TryFinish();
			}
		}

		public void MoveTo(int to)
		{
			if (_enabled)
			{
				CurrentColumn = Math.Clamp(to, 0, _numbers.GetLength(1) - 1);
				Moved?.Invoke(CurrentColumn);
			}
		}

		public void MoveLeft()
		{
			if (_enabled)
			{
				CurrentColumn = CurrentColumn - 1 < 0 ? _numbers.GetLength(1) - 1 : CurrentColumn - 1;
				Moved?.Invoke(CurrentColumn);
			}
		}

		public void MoveRight()
		{
			if (_enabled)
			{
				CurrentColumn = CurrentColumn + 1 > _numbers.GetLength(1) - 1 ? 0 : CurrentColumn + 1;
				Moved?.Invoke(CurrentColumn);
			}
		}

		private void TryFinish()
		{
			for (int i = 0; i < _numbers.GetLength(0); i++)
				if (SumLine(i) != Goal)
					return;

			_enabled = false;
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

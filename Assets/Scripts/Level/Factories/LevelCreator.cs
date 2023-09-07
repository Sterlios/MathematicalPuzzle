
using DataSource;
using LevelScene.Objects;
using MathPuzzleLogic.Control;
using MathPuzzleLogic.Factory;
using MathPuzzleLogic.Logic;
using UnityEngine;

namespace LevelScene.Factories
{
	public class LevelCreator
	{
		private readonly ISaver _saver;
		private readonly MathPuzzleCreator _mathPuzzleCreator;
		private readonly MechanismCreator _mechanismCreator;
		private readonly Controller _controller;
		private readonly UICreator _uICreator;

		public LevelCreator(
			ISaver saver,
			UICreator uICreator,
			MathPuzzleCreator mathPuzzleCreator,
			MechanismCreator mechanismCreator,
			Controller controller)
		{
			_saver = saver;
			_uICreator = uICreator;
			_mathPuzzleCreator = mathPuzzleCreator;
			_mechanismCreator = mechanismCreator;
			_controller = controller;
		}

		public Level Create(int rowsCount, int wheelsCount)
		{
			Level level = new GameObject().AddComponent<Level>();

			MathPuzzle puzzle = _mathPuzzleCreator.Create(rowsCount, wheelsCount);

			level.Initialize(_saver, puzzle, _controller, _mechanismCreator, _uICreator);

			return level;
		}
	}
}


using LevelScene.Objects;
using MathPuzzleLogic.Control;
using MathPuzzleLogic.Factory;
using MathPuzzleLogic.Logic;
using UnityEngine;

namespace LevelScene.Factories
{
	public class LevelCreator
	{
		private readonly MathPuzzleCreator _mathPuzzleCreator;
		private readonly MechanismCreator _mechanismCreator;
		private readonly Controller _controller;

		public LevelCreator(MathPuzzleCreator mathPuzzleCreator, MechanismCreator mechanismCreator, Controller controller)
		{
			_mathPuzzleCreator = mathPuzzleCreator;
			_mechanismCreator = mechanismCreator;
			_controller = controller;
		}

		public Level Create(int rowsCount, int wheelsCount)
		{
			Level level = new GameObject().AddComponent<Level>();

			MathPuzzle puzzle = _mathPuzzleCreator.Create(rowsCount, wheelsCount);

			level.Initialize(puzzle, _controller, _mechanismCreator);

			return level;
		}
	}
}

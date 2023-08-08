using Extention.UnityExtention;
using MathPuzzleLogic.Control;
using MathPuzzleLogic.Factory;
using MathPuzzleLogic.Logic;
using System.Collections.Generic;
using UnityEngine;
using UnityObjects.LevelObjects.Factories;
using UnityObjects.LevelObjects.Objects;
using UnityObjects.Scene.Panels;

namespace UnityObjects.Scene
{
	public class Level : MonoBehaviour
	{
		private static readonly System.Random _random = new System.Random();

		private MathPuzzleCreator _puzzleCreator;
		private CellCreator _cellCreator;
		private WheelCreator _wheelCreator;
		private ResultCellCreator _resultCellCreator;
		private MechanismCreator _mechanismCreator;

		private Controller _puzzleController;
		private WinPanel _winPanel;
		private MathPuzzle _puzzle;

		private int _goal;
		private int _wheelsCount;
		private int _raysCount;

		private void Awake()
		{
			_winPanel = FindObjectOfType<WinPanel>();
			_winPanel.gameObject.Deactivate();
			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
			_puzzle = _puzzleCreator.Create(_goal, _raysCount, _wheelsCount);
			ResultCell resultCell = _resultCellCreator.Create(_goal);
			List<Wheel> wheels = GenerateWheels(_puzzle);

			_ = _mechanismCreator.Create(spawnPoint, _puzzle, wheels, resultCell);

			_puzzleController.Initialize(_puzzle);
			_puzzle.Resolved += Finish;
		}

		private void Finish()
		{
			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}

		public void Initialize(
			int wheelsCount,
			int raysCount,
			Controller puzzleController,
			MathPuzzleCreator puzzleCreator,
			CellCreator cellCreator,
			WheelCreator wheelCreator,
			ResultCellCreator resultCellCreator,
			MechanismCreator mechanismCreator)
		{
			_wheelsCount = wheelsCount;
			_raysCount = raysCount;
			_goal = CalculateGoal();

			_puzzleController = puzzleController;
			_puzzleCreator = puzzleCreator;
			_cellCreator = cellCreator;
			_wheelCreator = wheelCreator;
			_resultCellCreator = resultCellCreator;
			_mechanismCreator = mechanismCreator;

			gameObject.Activate();
		}

		private int CalculateGoal()
		{
			int minGoal = 4;
			int maxGoal = 9;
			int goalMultiply = 10;

			return _random.Next(minGoal, maxGoal) * goalMultiply;
		}

		private List<Wheel> GenerateWheels(MathPuzzle puzzle)
		{
			List<Wheel> wheels = new(_wheelsCount);

			for (int i = 0; i < _wheelsCount; i++)
			{
				List<Cell> cells = GenerateCells(puzzle, i);
				wheels.Add(_wheelCreator.Create(i, cells));
			}

			return wheels;
		}

		private List<Cell> GenerateCells(MathPuzzle puzzle, int wheelIndex)
		{
			List<Cell> cells = new(_raysCount);

			for (int i = 0; i < _raysCount; i++)
				cells.Add(_cellCreator.Create(puzzle.GetValue(i, wheelIndex)));

			return cells;
		}
	}
}
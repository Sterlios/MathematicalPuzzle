using Extention.UnityExtention;
using MathPuzzleLogic.Control;
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

		private CellCreator _cellCreator;
		private WheelCreator _wheelCreator;
		private ResultCellCreator _resultCellCreator;
		private MechanismCreator _mechanismCreator;

		private Controller _puzzleController;
		private WinPanel _winPanel;
		private MathPuzzle _puzzle;

		private void Awake()
		{
			_winPanel = FindObjectOfType<WinPanel>();
			_winPanel.gameObject.Deactivate();
			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
			ResultCell resultCell = _resultCellCreator.Create(_puzzle.Goal);
			List<Wheel> wheels = GenerateWheels();

			_ = _mechanismCreator.Create(spawnPoint, _puzzle, wheels, resultCell);

			_puzzleController.Initialize(_puzzle);
			_puzzle.Resolved += Finish;
		}

		private void OnDisable()
		{
			_puzzle.Resolved -= Finish;
		}

		private void Finish()
		{
			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}

		public void Initialize(
			MathPuzzle puzzle,
			Controller puzzleController,
			CellCreator cellCreator,
			WheelCreator wheelCreator,
			ResultCellCreator resultCellCreator,
			MechanismCreator mechanismCreator)
		{
			_puzzle = puzzle;

			_puzzleController = puzzleController;
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

		private List<Wheel> GenerateWheels()
		{
			List<Wheel> wheels = new(_puzzle.WheelsCount);

			for (int i = 0; i < _puzzle.WheelsCount; i++)
			{
				List<Cell> cells = GenerateCells(i);
				wheels.Add(_wheelCreator.Create(i, cells));
			}

			return wheels;
		}

		private List<Cell> GenerateCells(int wheelIndex)
		{
			List<Cell> cells = new(_puzzle.RaysCount);

			for (int i = 0; i < _puzzle.RaysCount; i++)
				cells.Add(_cellCreator.Create(_puzzle.GetValue(i, wheelIndex)));

			return cells;
		}
	}
}
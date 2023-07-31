using System;
using System.Collections.Generic;
using UnityEngine;

namespace CookingNumbers
{
	public class Level : MonoBehaviour
	{
		private MathPuzzleCreator _puzzleCreator;
		private CellCreator _cellCreator;
		private WheelCreator _wheelCreator;
		private ResultCellCreator _resultCellCreator;
		private MechanismCreator _mechanismCreator;

		private MathPuzzleController _puzzleController;
		private WinPanel _winPanel;
		private MathPuzzle _puzzle;

		private readonly int _goal = 50;
		private readonly int _wheelsCount = 5;
		private readonly int _raysCount = 11;

		private void Awake()
		{
			//TODO вернутьс€, когда по€витс€ бутстрап и загрузка сцен
			_puzzleCreator = new MathPuzzleCreator();
			_cellCreator = new CellCreator();
			_wheelCreator = new WheelCreator();
			_resultCellCreator = new ResultCellCreator();
			_mechanismCreator = new MechanismCreator();

			_puzzleController = new MathPuzzleController(new MapControl());

			_winPanel = FindObjectOfType<WinPanel>();
			_winPanel.gameObject.Deactivate();
			//gameObject.Deactivate();
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

		public void Initialize(MathPuzzleController puzzleController, MathPuzzleCreator puzzleCreator, CellCreator cellCreator, WheelCreator wheelCreator, ResultCellCreator resultCellCreator, MechanismCreator mechanismCreator)
		{
			_puzzleController = puzzleController;
			_puzzleCreator = puzzleCreator;
			_cellCreator = cellCreator;
			_wheelCreator = wheelCreator;
			_resultCellCreator = resultCellCreator;
			_mechanismCreator = mechanismCreator;

			gameObject.Activate();
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
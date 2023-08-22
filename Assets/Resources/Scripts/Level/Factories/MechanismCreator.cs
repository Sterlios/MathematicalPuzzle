using MathPuzzleLogic.Logic;
using System.Collections.Generic;
using UnityEngine;
using LevelScene.Objects;

namespace LevelScene.Factories
{
	public class MechanismCreator
	{
		private readonly string _mechanismPrefabPath = "Prefabs/Map";
		private readonly WheelCreator _wheelCreator;
		private readonly CellCreator _cellCreator;
		private readonly ResultCellCreator _resultCellCreator;

		public MechanismCreator(WheelCreator wheelCreator, CellCreator cellCreator, ResultCellCreator resultCellCreator)
		{
			_wheelCreator = wheelCreator;
			_cellCreator = cellCreator;
			_resultCellCreator = resultCellCreator;
		}

		public Mechanism Create(SpawnPoint at, MathPuzzle puzzle)
		{
			ResultCell resultCell = _resultCellCreator.Create(puzzle.Goal);
			List<Wheel> wheels = GenerateWheels(puzzle);

			Mechanism mechanismPrefab = Resources.Load<Mechanism>(_mechanismPrefabPath);
			Mechanism mechanism = Object.Instantiate(mechanismPrefab, at.transform.position, Quaternion.identity);
			mechanism = mechanism.Initialize(puzzle, wheels, resultCell);

			return mechanism;
		}

		private List<Wheel> GenerateWheels(MathPuzzle puzzle)
		{
			List<Wheel> wheels = new(puzzle.WheelsCount);

			for (int i = 0; i < puzzle.WheelsCount; i++)
			{
				List<Cell> cells = GenerateCells(puzzle, i);
				wheels.Add(_wheelCreator.Create(i, cells));
			}

			return wheels;
		}

		private List<Cell> GenerateCells(MathPuzzle puzzle, int wheelIndex)
		{
			List<Cell> cells = new(puzzle.RaysCount);

			for (int i = 0; i < puzzle.RaysCount; i++)
				cells.Add(_cellCreator.Create(puzzle.GetValue(i, wheelIndex)));

			return cells;
		}
	}
}
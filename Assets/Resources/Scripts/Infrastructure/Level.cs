using System;
using System.Collections.Generic;
using UnityEngine;

namespace CookingNumbers
{
	public class Level : MonoBehaviour
	{
		private MathPazzleCreator _mapCreator;
		private CellCreator _cellCreator;
		private WheelCreator _wheelCreator;
		private ResultCellCreator _resultCellCreator;
		private MechanismCreator _mechanismCreator;

		private MathPazzleController _mapController;
		private WinPanel _winPanel;
		private MathPazzle _map;

		private readonly int _goal = 50;
		private readonly int _wheelsCount = 5;
		private readonly int _raysCount = 11;

		private void Awake()
		{
			//TODO вернутьс€, когда по€витс€ бутстрап и загрузка сцен
			_mapCreator = new MathPazzleCreator();
			_cellCreator = new CellCreator();
			_wheelCreator = new WheelCreator();
			_resultCellCreator = new ResultCellCreator();
			_mechanismCreator = new MechanismCreator();

			_mapController = new MathPazzleController(new MapControl());

			_winPanel = FindObjectOfType<WinPanel>();
			_winPanel.gameObject.Deactivate();
			//gameObject.Deactivate();
		}

		private void OnEnable()
		{
			SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
			_map = _mapCreator.Create(_goal, _raysCount, _wheelsCount);
			ResultCell resultCell = _resultCellCreator.Create(_goal);
			List<Wheel> wheels = GenerateWheels(_map);

			_ = _mechanismCreator.Create(spawnPoint, _map, wheels, resultCell);

			_mapController.Initialize(_map);
			_map.Resolved += Finish;

			Debug.Log(_map);
		}

		private void Finish()
		{
			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}

		public void Initialize(MathPazzleController mapController, MathPazzleCreator mapCreator, CellCreator cellCreator, WheelCreator wheelCreator, ResultCellCreator resultCellCreator, MechanismCreator mechanismCreator)
		{
			_mapController = mapController;
			_mapCreator = mapCreator;
			_cellCreator = cellCreator;
			_wheelCreator = wheelCreator;
			_resultCellCreator = resultCellCreator;
			_mechanismCreator = mechanismCreator;

			gameObject.Activate();
		}

		private List<Wheel> GenerateWheels(MathPazzle map)
		{
			List<Wheel> wheels = new(_wheelsCount);

			for (int i = 0; i < _wheelsCount; i++)
			{
				List<Cell> cells = GenerateCells(map, i);
				wheels.Add(_wheelCreator.Create(i, cells));
			}

			return wheels;
		}

		private List<Cell> GenerateCells(MathPazzle map, int wheelIndex)
		{
			List<Cell> cells = new(_raysCount);

			for (int i = 0; i < _raysCount; i++)
				cells.Add(_cellCreator.Create(map.GetValue(i, wheelIndex)));

			return cells;
		}
	}
}
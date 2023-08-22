using System.Collections.Generic;
using UnityEngine;
using LevelScene.Objects;

namespace LevelScene.Factories
{
	public class WheelCreator
	{
		private readonly string _wheelPath = "Prefabs/Wheel";

		public Wheel Create(int index, List<Cell> cells)
		{
			Wheel wheelPrefab = Resources.Load<Wheel>(_wheelPath);
			Wheel wheel = Object.Instantiate(wheelPrefab);

			wheel.Initialize(index, cells);

			return wheel;
		}
	}
}

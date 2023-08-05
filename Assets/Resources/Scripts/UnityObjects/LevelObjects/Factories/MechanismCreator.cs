using UnityObjects.LevelObjects.Objects;
using MathPuzzleLogic.Logic;
using System.Collections.Generic;
using UnityEngine;

namespace UnityObjects.LevelObjects.Factories
{
	public class MechanismCreator
	{
		private readonly string _mechanismPrefabPath = "Prefabs/Map";

		public Mechanism Create(SpawnPoint at, MathPuzzle puzzle, List<Wheel> wheels, ResultCell resultCell)
		{
			Mechanism mechanismPrefab = Resources.Load<Mechanism>(_mechanismPrefabPath);
			Mechanism mechanism = Object.Instantiate(mechanismPrefab, at.transform.position, Quaternion.identity);
			mechanism = mechanism.Initialize(puzzle, wheels, resultCell);

			return mechanism;
		}
	}
}
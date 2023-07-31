using System.Collections.Generic;
using UnityEngine;

namespace CookingNumbers
{
	public class MechanismCreator
	{
		private readonly string _mechanismPrefabPath = "Prefabs/Map";

		public Mechanism Create(SpawnPoint at, MathPazzle map, List<Wheel> wheels, ResultCell resultCell)
		{
			Mechanism mechanismPrefab = Resources.Load<Mechanism>(_mechanismPrefabPath);
			Mechanism mechanism = Object.Instantiate(mechanismPrefab, at.transform);
			mechanism = mechanism.Initialize(map, wheels, resultCell);

			return mechanism;
		}
	}
}
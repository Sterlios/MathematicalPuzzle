using UnityObjects.LevelObjects.Objects;
using UnityEngine;

namespace UnityObjects.LevelObjects.Factories
{
	public class CellCreator
	{
		private readonly string _cellPath = "Prefabs/Cell";

		public Cell Create(int value)
		{
			Cell cellPrefab = Resources.Load<Cell>(_cellPath);
			Cell cell = Object.Instantiate(cellPrefab);

			cell.Initialize(value);

			return cell;
		}
	}
}

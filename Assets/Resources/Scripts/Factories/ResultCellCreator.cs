
using UnityEngine;

namespace CookingNumbers
{
	public class ResultCellCreator
	{
		private readonly string _resultCellPath = "Prefabs/Result";

		public ResultCell Create(int goal)
		{
			ResultCell resultCellPrefab = Resources.Load<ResultCell>(_resultCellPath);
			ResultCell resultCell = Object.Instantiate(resultCellPrefab);

			resultCell.Initialize(goal);

			return resultCell;
		}
	}
}

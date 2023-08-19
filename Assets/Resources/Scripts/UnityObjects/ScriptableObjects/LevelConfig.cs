using UnityEngine;

namespace UnityObjects.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Level", menuName = "Levels/Level")]
	public class LevelConfig : ScriptableObject
	{
		[SerializeField] private int _rowsCount;
		[SerializeField] private int _wheelsCount;

		public int RowsCount => _rowsCount;
		public int WheelsCount => _wheelsCount;
	}
}

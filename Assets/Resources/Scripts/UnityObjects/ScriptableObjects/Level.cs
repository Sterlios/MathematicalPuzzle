
using UnityEngine;

namespace UnityObjects.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Level", menuName = "Levels/Level")]
	public class Level : ScriptableObject
	{
		[SerializeField] private int _rowsCount;
		[SerializeField] private int _wheelsCount;
		[SerializeField] private LevelStatus _status;

		public int RowsCount => _rowsCount;
		public int WheelsCount => _wheelsCount;
		public LevelStatus Status => _status;

		public void Open()
		{
			_status = LevelStatus.NotPlaying;
		}

		public void Play()
		{
			_status = LevelStatus.NotDone;
		}

		public void Finish()
		{
			_status = LevelStatus.Done;
		}
	}
}

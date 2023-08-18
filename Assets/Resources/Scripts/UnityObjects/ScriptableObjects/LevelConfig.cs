
using MathPuzzleLogic.Logic;
using UnityEngine;

namespace UnityObjects.ScriptableObjects
{
	[CreateAssetMenu(fileName = "Level", menuName = "Levels/Level")]
	public class LevelConfig : ScriptableObject
	{
		[SerializeField] private int _rowsCount;
		[SerializeField] private int _wheelsCount;
		[SerializeField] private LevelStatus _status;

		private MathPuzzle _puzzle;

		public int RowsCount => _rowsCount;
		public int WheelsCount => _wheelsCount;
		public LevelStatus Status => _status;
		public MathPuzzle Puzzle => _puzzle;

		public void Initialize(MathPuzzle puzzle)
		{
			_puzzle = puzzle;
		}

		public void Save()
		{
		}

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
			_puzzle = null;
			_status = LevelStatus.Done;
		}
	}
}

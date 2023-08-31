using MathPuzzleLogic.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelScene.UI
{
	public class PuzzleControl : MonoBehaviour
	{
		[SerializeField] private Button _prevWheelButton;
		[SerializeField] private Button _nextWheelButton;
		[SerializeField] private Button _rotateLeftButton;
		[SerializeField] private Button _rotateRightButton;

		private MathPuzzle _puzzle;

		private void OnEnable()
		{
			SubscribeButtons();
		}

		private void OnDisable()
		{
			UnsubscribeButtons();
		}

		public void Initialize(MathPuzzle puzzle)
		{
			_puzzle = puzzle;

			SubscribeButtons();
		}

		private void SubscribeButtons()
		{
			if (_puzzle is not null)
			{
				_prevWheelButton.onClick.AddListener(_puzzle.MoveRight);
				_nextWheelButton.onClick.AddListener(_puzzle.MoveLeft);
				_rotateLeftButton.onClick.AddListener(_puzzle.ShiftUp);
				_rotateRightButton.onClick.AddListener(_puzzle.ShiftDown);
			}
		}

		private void UnsubscribeButtons()
		{
			if (_puzzle is not null)
			{
				_prevWheelButton.onClick.AddListener(_puzzle.MoveRight);
				_nextWheelButton.onClick.AddListener(_puzzle.MoveLeft);
				_rotateLeftButton.onClick.AddListener(_puzzle.ShiftUp);
				_rotateRightButton.onClick.AddListener(_puzzle.ShiftDown);
			}
		}
	}
}

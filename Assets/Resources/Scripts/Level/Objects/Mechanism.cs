using MathPuzzleLogic.Logic;
using System.Collections.Generic;
using UnityEngine;
using Extention.UnityExtention;

namespace LevelScene.Objects
{
	public class Mechanism : MonoBehaviour
	{
		private MathPuzzle _puzzle;
		private List<Wheel> _wheels;
		private Wheel _currentWheel;

		private readonly float _defaultHeight = 1;

		private void Awake()
		{
			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			_puzzle.ShiftedUp += OnSwiftedUp;
			_puzzle.ShiftedDown += OnSwiftedDown;
			_puzzle.Moved += ChooseWheel;

			ChooseWheel(_puzzle.CurrentColumn);
		}

		private void OnDisable()
		{
			if (_puzzle != null)
			{
				_puzzle.ShiftedUp -= OnSwiftedUp;
				_puzzle.ShiftedDown -= OnSwiftedDown;
				_puzzle.Moved -= ChooseWheel;
			}
		}

		public Mechanism Initialize(MathPuzzle puzzle, List<Wheel> wheels, ResultCell resultCell)
		{
			_wheels = wheels;
			_puzzle = puzzle;

			TakeWheelsParent();
			resultCell.transform.parent = transform;

			SetHeight();

			gameObject.Activate();
			
			return this;
		}

		private void SetHeight()
		{
			float newHeight = transform.position.y + _defaultHeight * _wheels.Count;

			transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
		}

		private void TakeWheelsParent()
		{
			foreach (Wheel wheel in _wheels)
				wheel.transform.parent = transform;
		}

		private void OnSwiftedUp()
		{
			_currentWheel.RotateUp();
		}

		private void OnSwiftedDown()
		{
			_currentWheel.RotateDown();
		}

		private void ChooseWheel(int index)
		{
			_currentWheel?.ResetColor();

			_currentWheel = _wheels[index];
			_currentWheel.Highlight();
		}
	}
}
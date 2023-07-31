using System.Collections.Generic;
using UnityEngine;

namespace CookingNumbers
{
	public class Mechanism : MonoBehaviour
	{
		private MathPazzle _pazzle;
		private List<Wheel> _wheels;
		private Wheel _currentWheel;

		private readonly float _defaultHeight = 1;

		private void Awake()
		{
			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			_pazzle.ShiftedUp += OnSwiftedUp;
			_pazzle.ShiftedDown += OnSwiftedDown;
			_pazzle.Moved += ChooseWheel;

			ChooseWheel(_pazzle.CurrentColumn);
		}

		private void OnDisable()
		{
			if (_pazzle != null)
			{
				_pazzle.ShiftedUp -= OnSwiftedUp;
				_pazzle.ShiftedDown -= OnSwiftedDown;
				_pazzle.Moved -= ChooseWheel;
			}
		}

		public Mechanism Initialize(MathPazzle pazzle, List<Wheel> wheels, ResultCell resultCell)
		{
			_wheels = wheels;
			_pazzle = pazzle;

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
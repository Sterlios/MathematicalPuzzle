using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScene.Objects
{
	[RequireComponent(typeof(MeshRenderer))]
	public class Wheel : MonoBehaviour
	{
		private readonly int _startSize = 5;
		private readonly float _maxAngle = 360f;
		private readonly Color _highlightColor = new(0.7311321f, 1f, 0.7361851f);
		private readonly float _epsilon = 0.01f;
		private readonly int _digitsCount = 6;

		private float _angle;
		private Color _defaultColor;
		private List<Cell> _cells;
		private int _index;
		private Coroutine _rotateCoroutine;
		private float _currentAngle;
		private Material _material;

		private void Awake()
		{
			_material = GetComponent<MeshRenderer>().materials[0];

			_currentAngle = transform.rotation.eulerAngles.y;

			_defaultColor = _material.color;
		}

		public void Initialize(int index, List<Cell> cells)
		{
			_index = index;
			_cells = cells;
			_angle = (float)Math.Round(_maxAngle / _cells.Count, _digitsCount);

			CalculateSize();
			TakeCellsParent();
			SetHeight();
			MoveCells();
		}

		public void RotateUp()
		{
			Rotate(_angle);
		}

		public void RotateDown()
		{
			Rotate(-_angle);
		}

		public void ResetColor()
		{
			_material.color = _defaultColor;
		}

		public void Highlight()
		{
			_material.color = _highlightColor;
		}

		private void MoveCells()
		{
			float radius = GetComponent<MeshRenderer>().bounds.extents.x;

			for (int i = 0; i < _cells.Count; i++)
			{
				float angle = _angle * i;

				_cells[i].SetPosition(radius);
				_cells[i].Rotate(angle, transform.position);
			}
		}

		private void SetHeight()
		{
			float newHeight = transform.position.y - _index;

			transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
		}

		private void Rotate(float angle)
		{
			CalculateRotation(angle);

			if (_rotateCoroutine != null)
				StopCoroutine(_rotateCoroutine);

			_rotateCoroutine = StartCoroutine(RotateRoutine(angle));
		}

		private void CalculateRotation(float angle)
		{
			_currentAngle += angle * (-1);

			float deltaAngle = Mathf.Abs(_currentAngle - _maxAngle);

			if (_currentAngle > _maxAngle)
				_currentAngle -= _maxAngle;
			else if (_currentAngle < 0)
				_currentAngle += _maxAngle;

			if (Math.Abs(_currentAngle) < _epsilon || Math.Abs(deltaAngle) < _epsilon)
				_currentAngle = 0;
		}

		private IEnumerator RotateRoutine(float angle)
		{
			const int StepsCount = 10;
			float angleStep = (float)Math.Round(angle * (-1) / StepsCount, _digitsCount);
			float correctingEpsilon = 0.0005f;

			while (Mathf.Abs(transform.rotation.eulerAngles.y - _currentAngle) > _epsilon)
			{
				transform.Rotate(Quaternion.AngleAxis(angleStep, Vector3.up).eulerAngles);

				yield return null;
			}

			float newAngle = _currentAngle - transform.rotation.eulerAngles.y;

			if (Mathf.Abs(newAngle) > correctingEpsilon)
				transform.Rotate(Quaternion.AngleAxis(newAngle, Vector3.up).eulerAngles);
		}

		private void CalculateSize()
		{
			int newSize = _startSize + _startSize * (_index + 1);
			transform.localScale = new Vector3(newSize, transform.localScale.y, newSize);
		}

		private void TakeCellsParent()
		{
			foreach (Cell cell in _cells)
				cell.transform.parent = transform;
		}
	}
}
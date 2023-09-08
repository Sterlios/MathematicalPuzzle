using UnityEngine;

namespace LevelScene.Objects
{
	public class Cell : MonoBehaviour
	{
		private CellNumber _cellNumber;

		private void Awake()
		{
			_cellNumber = GetComponentInChildren<CellNumber>();
		}

		public void Initialize(int value)
		{
			_cellNumber.Initialize(value);
		}

		public void SetPosition(float radius)
		{
			float newPositionX = transform.position.x + radius;

			transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
		}

		public void Rotate(float angle, Vector3 centerPoint)
		{
			transform.RotateAround(centerPoint, Vector3.up, angle);
			ResetNumberRotation();
		}

		public void ResetNumberRotation()
		{
			_cellNumber.ResetRotation();
		}
	}
}
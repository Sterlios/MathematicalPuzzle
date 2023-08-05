using TMPro;
using UnityEngine;

namespace UnityObjects.LevelObjects.Objects
{
	public class Cell : MonoBehaviour
	{
		private TMP_Text _valueText;

		private void Awake()
		{
			_valueText = GetComponentInChildren<TextMeshPro>();
		}

		public void Initialize(int value)
		{
			_valueText.text = value.ToString();
		}

		internal void SetPosition(float radius)
		{
			float newPositionX = transform.position.x + radius;

			transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
		}

		internal void Rotate(float angle, Vector3 centerPoint)
		{
			transform.RotateAround(centerPoint, Vector3.up, angle);
		}
	}
}
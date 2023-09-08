using TMPro;
using UnityEngine;

namespace LevelScene.Objects
{
	[RequireComponent(typeof(TextMeshPro))]
	[RequireComponent(typeof(RectTransform))]
	public class CellNumber : MonoBehaviour
	{
		private TextMeshPro _number;
		private RectTransform _rectTransform;
		private Quaternion _defaultAngle;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_number = GetComponent<TextMeshPro>();
			_defaultAngle = _rectTransform.localRotation;
		}

		public void Initialize(int value)
		{
			_number.text = value.ToString();
		}

		public void ResetRotation()
		{
			_rectTransform.rotation = _defaultAngle;
		}
	}
}

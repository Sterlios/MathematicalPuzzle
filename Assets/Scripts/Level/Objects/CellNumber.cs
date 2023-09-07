using TMPro;
using UnityEngine;

namespace LevelScene.Objects
{
	[RequireComponent(typeof(TextMeshPro))]
	public class CellNumber : MonoBehaviour
	{
		private TextMeshPro _number;

		private void Awake()
		{
			_number = GetComponent<TextMeshPro>();
		}

		public void Initialize(int value)
		{
			_number.text = value.ToString();
		}

		public void ResetRotation()
		{
			transform.rotation = new Quaternion(90f,0,0,1);
		}
	}
}

using TMPro;
using UnityEngine;

namespace CookingNumbers
{
	[RequireComponent(typeof(TMP_Text))]
	internal class NumberView : MonoBehaviour
	{
		private TMP_Text _textField;

		private void Awake()
		{
			_textField = GetComponent<TMP_Text>();
		}

		public void Initialize(int number)
		{
			_textField.text = number.ToString();
		}
	}
}
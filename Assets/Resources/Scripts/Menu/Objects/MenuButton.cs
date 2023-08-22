
using UnityEngine;
using UnityEngine.UI;

namespace MenuScene.Objects
{
	public class MenuButton: MonoBehaviour
	{
		private Button _button;

		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			
		}
	}
}

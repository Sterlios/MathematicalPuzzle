
using UnityEngine;
using UnityEngine.UI;

namespace UnityObjects.MenuObjects
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

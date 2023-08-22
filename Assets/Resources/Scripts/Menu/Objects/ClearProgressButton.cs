
using UnityEngine;

namespace MenuScene.Objects
{
	internal class ClearProgressButton : MonoBehaviour
	{
		private Menu _menu;

		private void Awake()
		{
			_menu = GetComponentInParent<Menu>();
		}

		public void ClearProgress()
		{
			PlayerPrefs.DeleteAll();
			_menu.UpdateLevelStatuses();
		}
	}
}

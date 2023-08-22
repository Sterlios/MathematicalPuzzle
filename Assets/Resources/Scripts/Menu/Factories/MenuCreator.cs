
using MenuScene.Objects;
using UnityEngine;

namespace MenuScene.Factories
{
	public class MenuCreator
	{
		private readonly string _menuPrefabPath = "Prefabs/Menu";

		public Menu Create()
		{
			Menu menuPrefab = Resources.Load<Menu>(_menuPrefabPath);
			Menu menu = Object.Instantiate(menuPrefab);

			return menu;
		}
	}
}

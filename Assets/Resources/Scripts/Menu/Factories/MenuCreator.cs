
using DataSource;
using MenuScene.Objects;
using UnityEngine;

namespace MenuScene.Factories
{
	public class MenuCreator
	{
		private readonly string _menuPrefabPath = "Prefabs/Menu";
		private readonly ILoader _loader;
		private readonly ISaver _saver;

		public MenuCreator(ILoader loader, ISaver saver)
		{
			_loader = loader;
			_saver = saver;
		}

		public Menu Create()
		{
			Menu menuPrefab = Resources.Load<Menu>(_menuPrefabPath);
			Menu menu = Object.Instantiate(menuPrefab);

			menu.Initialize(_loader, _saver);

			return menu;
		}
	}
}

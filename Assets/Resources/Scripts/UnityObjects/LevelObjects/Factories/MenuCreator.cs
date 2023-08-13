
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityObjects.Scene.Bootstrap;

namespace UnityObjects.LevelObjects.Factories
{
	public class MenuCreator
	{
		private readonly string _menuPrefabPath = "Prefabs/Menu";

		public Menu Create(ISceneLoader sceneLoader)
		{
			Menu menuPrefab = Resources.Load<Menu>(_menuPrefabPath);
			Menu menu = GameObject.Instantiate(menuPrefab);

			menu.Initialize(sceneLoader);

			return menu;
		}
	}
}

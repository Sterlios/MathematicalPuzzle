using UnityEngine;

namespace LevelScene.Factories
{
	public class UICreator
	{
		private readonly string _uiPrefabPath = "Prefabs/LevelUICanvas";

		public UICanvas Create()
		{
			UICanvas uiCanvasPrefab = Resources.Load<UICanvas>(_uiPrefabPath);
			UICanvas uiCanvas = Object.Instantiate(uiCanvasPrefab);

			return uiCanvas;
		}
	}
}

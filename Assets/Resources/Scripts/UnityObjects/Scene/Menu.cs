using Extention.UnityExtention;
using UnityEngine;
using UnityObjects.Scene.Bootstrap;

namespace UnityObjects
{
    public class Menu : MonoBehaviour
    {
		public void Initialize(ISceneLoader sceneLoader)
		{
			LevelCell[] cells = GetComponentsInChildren<LevelCell>();

			foreach(LevelCell cell in cells)
				cell.Initialize(sceneLoader);
		}
	}
}

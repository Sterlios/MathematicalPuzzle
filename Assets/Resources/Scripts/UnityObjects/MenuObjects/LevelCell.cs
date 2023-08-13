
using UnityEngine;
using UnityObjects.Scene.Bootstrap;

namespace UnityObjects
{
    public class LevelCell : MonoBehaviour
    {
        [SerializeField] private int _wheelsCount;
        [SerializeField] private int _raysCount;

        [SerializeField] private ISceneLoader _sceneLoader;

        public void Initialize(ISceneLoader sceneLoader)
		{
            _sceneLoader = sceneLoader;
		}

		public void OnButtonClick()
		{
            _sceneLoader.LoadLevel(_wheelsCount, _raysCount);
		}
    }
}


using Extention.UnityExtention;
using UnityEngine;
using UnityEngine.UI;
using UnityObjects.Scene.Bootstrap;

namespace UnityObjects.LevelObjects.Objects
{
	internal class BackMenuButton : MonoBehaviour
	{
		private Button _button;

		private ISceneLoader _sceneLoader;

		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			if (_sceneLoader is not null)
				_button.onClick.AddListener(_sceneLoader.LoadMenu);
		}

		private void OnDisable()
		{
			if (_sceneLoader is not null)
				_button.onClick.RemoveListener(_sceneLoader.LoadMenu);
		}

		internal void Initialize(ISceneLoader sceneLoader)
		{
			_sceneLoader = sceneLoader;
			_button.onClick.AddListener(_sceneLoader.LoadMenu);
		}
	}
}

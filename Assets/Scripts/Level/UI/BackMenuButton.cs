
using System;
using UnityEngine;
using UnityEngine.UI;

namespace LevelScene.UI
{
	internal class BackMenuButton : MonoBehaviour
	{
		private Button _button;

		public event Action Clicked;

		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.AddListener(OnClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnClick);
		}

		private void OnClick()
		{
			Clicked?.Invoke();
		}
	}
}

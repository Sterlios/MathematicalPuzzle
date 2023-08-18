
using Extention.UnityExtention;
using UnityEngine;
using UnityObjects.Scene.Bootstrap;
using UnityObjects.ScriptableObjects;

namespace UnityObjects
{
	public class LevelCell : MonoBehaviour
	{
		[SerializeField] private Level _level;
		[SerializeField] private GameObject _number;
		[SerializeField] private GameObject _doneItem;
		[SerializeField] private GameObject _notDoneItem;
		[SerializeField] private GameObject _notPlayingItem;
		[SerializeField] private GameObject _lockItem;

		private ISceneLoader _sceneLoader;

		public LevelStatus Status => _level.Status;

		private void Awake()
		{
			UpdateStatusView();
		}

		public void Initialize(ISceneLoader sceneLoader)
		{
			_sceneLoader = sceneLoader;
		}

		public void OnButtonClick()
		{
			if (_level.Status == LevelStatus.Lock)
				return;

			Debug.Log(_sceneLoader);
			_sceneLoader.LoadLevel(_level);
		}

		public void Open()
		{
			_level.Open();
			UpdateStatusView();
		}

		private void UpdateStatusView()
		{
			_number.Deactivate();
			_doneItem.Deactivate();
			_notDoneItem.Deactivate();
			_notPlayingItem.Deactivate();
			_lockItem.Deactivate();

			if (_level.Status == LevelStatus.Lock)
			{
				_lockItem.Activate();
				return;
			}

			_number.Activate();

			if (_level.Status == LevelStatus.NotPlaying)
				_notPlayingItem.Activate();
			else if (_level.Status == LevelStatus.NotDone)
				_notDoneItem.Activate();
			else
				_doneItem.Activate();
		}
	}
}


using Extention.UnityExtention;
using UnityEngine;
using UnityObjects.Scene.Bootstrap;
using UnityObjects.ScriptableObjects;

namespace UnityObjects
{
	public class LevelCell : MonoBehaviour
	{
		[SerializeField] private LevelConfig _level;
		[SerializeField] private GameObject _number;
		[SerializeField] private GameObject _doneItem;
		[SerializeField] private GameObject _notDoneItem;
		[SerializeField] private GameObject _notPlayingItem;
		[SerializeField] private GameObject _lockItem;
		[SerializeField] private LevelStatus _status;

		private ISceneLoader _sceneLoader;

		private string Key => $"{_level.RowsCount}:{_level.WheelsCount}";
		public LevelStatus Status => _status;

		private void Awake()
		{
			Load();
			UpdateStatusView();
		}

		public void Initialize(ISceneLoader sceneLoader)
		{
			_sceneLoader = sceneLoader;
		}

		public void OnButtonClick()
		{
			if (_status == LevelStatus.Lock)
				return;

			Save();
			_sceneLoader.LoadLevel(_level);
		}

		private void Save()
		{
			PlayerPrefs.SetInt(Key, (int)_status);
			PlayerPrefs.Save();
		}

		private void Load()
		{
			if (PlayerPrefs.HasKey(Key))
				_status = (LevelStatus)PlayerPrefs.GetInt(Key);
			else
				_status = LevelStatus.Lock;
		}

		public void Open()
		{
			_status = LevelStatus.NotPlaying;
			UpdateStatusView();
		}

		public void Finish()
		{
			_status = LevelStatus.Done;
		}

		private void UpdateStatusView()
		{
			_number.Deactivate();
			_doneItem.Deactivate();
			_notDoneItem.Deactivate();
			_notPlayingItem.Deactivate();
			_lockItem.Deactivate();

			if (_status == LevelStatus.Lock)
			{
				_lockItem.Activate();
				return;
			}

			_number.Activate();

			if (_status == LevelStatus.NotPlaying)
				_notPlayingItem.Activate();
			else if (_status == LevelStatus.NotDone)
				_notDoneItem.Activate();
			else
				_doneItem.Activate();
		}
	}
}

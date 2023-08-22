
using DataSource;
using Extention.UnityExtention;
using System;
using UnityEngine;

namespace MenuScene.Objects
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

		private ILoader _loader;
		private ISaver _saver;

		public event Action<LevelConfig> Clicked;

		public LevelConfig Config => _level;
		private string Key => $"{_level.RowsCount}:{_level.WheelsCount}";
		public LevelStatus Status => _status;

		private void Awake()
		{
			//gameObject.Deactivate();
		}

		private void OnEnable()
		{
			UpdateStatus();

			UpdateStatusView();
		}

		public void Initialize(ILoader loader, ISaver saver)
		{
			gameObject.Deactivate();

			_loader = loader;
			_saver = saver;

			gameObject.Activate();
		}

		public void UpdateStatus()
		{
			if (_loader is not null)
				_status = _loader.Load(Key);
		}

		public void OnButtonClick()
		{
			if (_status == LevelStatus.Lock)
				return;

			Clicked?.Invoke(_level);
		}

		public void Open()
		{
			_status = LevelStatus.NotPlaying;
			_saver.Save(Key, _status);
			UpdateStatusView();
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

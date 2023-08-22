using DataSource;
using Extention.UnityExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MenuScene.Objects
{
	public class Menu : MonoBehaviour
	{
		private List<LevelCell> _levels;
		private ILoader _loader;
		private ISaver _saver;

		public event Action<LevelConfig> Exited;

		private void Awake()
		{
			_levels = GetComponentsInChildren<LevelCell>().ToList();

			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			foreach (LevelCell level in _levels)
			{
				level.Initialize(_loader, _saver);
				level.Clicked += MoveToLevel;
			}

			UnlockNewLevels();
		}

		private void OnDisable()
		{
			foreach (LevelCell level in _levels)
				level.Clicked -= MoveToLevel;
		}

		public void Initialize(ILoader loader, ISaver saver)
		{
			_loader = loader;
			_saver = saver;
			gameObject.Activate();
		}

		public void UpdateLevelStatuses()
		{
			foreach (LevelCell level in _levels)
				level.UpdateStatus();

			UnlockNewLevels();
		}

		public void UnlockNewLevels()
		{
			int maxNotLockAndNotDoneLevelsCount = 3;
			int currentNotLockAndNotDoneLevelsCount = GetNotLockAndNotDoneLevelsCount();
			int unlockingLevelsCount = maxNotLockAndNotDoneLevelsCount - currentNotLockAndNotDoneLevelsCount;

			List<LevelCell> lockedLevels = GetLockedLevels();

			for (int i = 0; i < unlockingLevelsCount; i++)
				if (i < lockedLevels.Count)
					lockedLevels[i].Open();
		}

		private void MoveToLevel(LevelConfig levelConfig)
		{
			Exited?.Invoke(levelConfig);
		}

		private List<LevelCell> GetLockedLevels() =>
			_levels.Where(level => level.Status == LevelStatus.Lock).ToList();

		private int GetNotLockAndNotDoneLevelsCount() =>
			_levels.Where(level => level.Status != LevelStatus.Lock && level.Status != LevelStatus.Done).ToList().Count;
	}
}

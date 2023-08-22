using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MenuScene.Objects
{
	public class Menu : MonoBehaviour
	{
		private List<LevelCell> _levels;

		public event Action<LevelConfig> Exited;

		private void Awake()
		{
			_levels = GetComponentsInChildren<LevelCell>().ToList();

			UnlockNewLevels();
		}

		private void OnEnable()
		{
			foreach (LevelCell level in _levels)
				level.Clicked += MoveToLevel;
		}

		private void OnDisable()
		{
			foreach (LevelCell level in _levels)
				level.Clicked -= MoveToLevel;
		}

		private void MoveToLevel(LevelConfig levelConfig)
		{
			Exited?.Invoke(levelConfig);
		}

		private void UnlockNewLevels()
		{
			int maxNotLockAndNotDoneLevelsCount = 3;
			int currentNotLockAndNotDoneLevelsCount = GetNotLockAndNotDoneLevelsCount();
			int unlockingLevelsCount = maxNotLockAndNotDoneLevelsCount - currentNotLockAndNotDoneLevelsCount;

			List<LevelCell> lockedLevels = GetLockedLevels();

			for (int i = 0; i < unlockingLevelsCount; i++)
				if (i < lockedLevels.Count)
					lockedLevels[i].Open();
		}

		private List<LevelCell> GetLockedLevels() =>
			_levels.Where(level => level.Status == LevelStatus.Lock).ToList();

		private int GetNotLockAndNotDoneLevelsCount() =>
			_levels.Where(level => level.Status != LevelStatus.Lock && level.Status != LevelStatus.Done).ToList().Count;
	}
}

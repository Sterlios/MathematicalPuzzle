
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityObjects.Scene.Bootstrap;

namespace UnityObjects
{
    public class Menu : MonoBehaviour
    {
		public void Initialize(ISceneLoader sceneLoader)
		{
			List<LevelCell> cells = GetComponentsInChildren<LevelCell>().ToList();

			foreach(LevelCell cell in cells)
				cell.Initialize(sceneLoader);

			int maxNotLockAndNotDoneLevelsCount = 3;
			int currentNotLockAndNotDoneLevelsCount = GetNotLockAndNotDoneLevelsCount(cells);
			int unlockingLevelsCount = maxNotLockAndNotDoneLevelsCount - currentNotLockAndNotDoneLevelsCount;

			List<LevelCell> lockedLevels = GetLockedLevels(cells);

			for (int i = 0; i < unlockingLevelsCount; i++)
				lockedLevels[i].Open();
		}

		private List<LevelCell> GetLockedLevels(List<LevelCell> levels) =>
			levels.Where(level => level.Status == LevelStatus.Lock).ToList();

		private int GetNotLockAndNotDoneLevelsCount(List<LevelCell> levels) =>
			levels.Where(level => level.Status != LevelStatus.Lock && level.Status != LevelStatus.Done).ToList().Count;
	}
}

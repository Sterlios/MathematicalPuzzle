using UnityEngine;

namespace DataSource
{
	public class DataSourceManager : ISaver, ILoader
	{
		public LevelStatus Load(string key)
		{
			LevelStatus status = LevelStatus.Lock;

			if (PlayerPrefs.HasKey(key))
				status = (LevelStatus)PlayerPrefs.GetInt(key);

			return status;
		}

		public void Save(string key, LevelStatus status)
		{
			PlayerPrefs.SetInt(key, (int)status);
			PlayerPrefs.Save();
		}
	}
}

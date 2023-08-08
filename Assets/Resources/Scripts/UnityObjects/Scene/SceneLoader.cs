﻿using UnityEngine.SceneManagement;
using UnityObjects.Scene.Panels;

namespace UnityObjects.Scene
{
	internal class SceneLoader
	{
		private readonly Curtain _curtain;

		public SceneLoader(Curtain curtain)
		{
			_curtain = curtain;
		}

		public void Load(string sceneName)
		{
			_curtain.Show();

			var operation = SceneManager.LoadSceneAsync(sceneName);
			
			while (operation.isDone)
				continue; 

			_curtain.Hide();
		}
	}
}
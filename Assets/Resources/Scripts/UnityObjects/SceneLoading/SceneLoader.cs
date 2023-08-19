using MathPuzzleLogic.Control;
using MathPuzzleLogic.Factory;
using MathPuzzleLogic.Logic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityObjects.LevelObjects.Factories;
using UnityObjects.Scene;
using UnityObjects.Scene.Bootstrap;
using UnityObjects.SceneLoading.Loading;

namespace UnityObjects.SceneLoading
{
	public class SceneLoader
	{
		private const string MenuSceneName = "Menu";
		private const string LevelSceneName = "Level";

		private readonly Curtain _curtain;

		public SceneLoader(Curtain curtain)
		{
			_curtain = curtain;
		}

		public IEnumerator LoadMenu(ISceneLoader sceneLoader, MenuCreator menuCreator)
		{
			_curtain.Show();

			var operation = SceneManager.LoadSceneAsync(MenuSceneName);

			while (!operation.isDone)
				yield return null;

			menuCreator.Create(sceneLoader);

			_curtain.Hide();
		}

		public IEnumerator LoadLevel(ScriptableObjects.LevelConfig levelConfig, ISceneLoader sceneLoader, Controller controller, MathPuzzleCreator mathPuzzleCreator, MechanismCreator mechanismCreator)
		{
			_curtain.Show();

			var operation = SceneManager.LoadSceneAsync(LevelSceneName);

			while (!operation.isDone)
				yield return null;

			Level level = new GameObject().AddComponent<Level>();

			MathPuzzle puzzle = mathPuzzleCreator.Create(levelConfig.RowsCount, levelConfig.WheelsCount);

			level.Initialize(sceneLoader, puzzle, controller, mechanismCreator);

			_curtain.Hide();
		}
	}
}

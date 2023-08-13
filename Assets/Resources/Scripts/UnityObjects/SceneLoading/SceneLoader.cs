using MathPuzzleLogic.Control;
using MathPuzzleLogic.Factory;
using MathPuzzleLogic.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityObjects.LevelObjects.Factories;
using UnityObjects.Scene;
using UnityObjects.SceneLoading.Loading;

namespace UnityObjects.SceneLoading
{
	public class SceneLoader
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

		public void Load(string sceneName, int wheelsCount, int raysCount, Controller controller, MathPuzzleCreator mathPuzzleCreator, MechanismCreator mechanismCreator)
		{
			_curtain.Show();

			var operation = SceneManager.LoadSceneAsync(sceneName);

			while (operation.isDone)
				continue;

			MathPuzzle puzzle = mathPuzzleCreator.Create(raysCount, wheelsCount);
			Level level = GameObject.FindObjectOfType<Level>();

			level.Initialize(puzzle, controller, mechanismCreator);

			_curtain.Hide();
		}
	}
}

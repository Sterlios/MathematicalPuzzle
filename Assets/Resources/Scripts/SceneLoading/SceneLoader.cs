using Curtain;
using LevelScene.Factories;
using LevelScene.Objects;
using MenuScene.Factories;
using MenuScene.Objects;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
	public class SceneLoader : ISceneLoader
	{
		private const string MenuSceneName = "Menu";
		private const string LevelSceneName = "Level";

		private readonly LoadingCurtain _curtain;
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly LevelCreator _levelCreator;
		private readonly MenuCreator _menuCreator;
		private Coroutine _coroutine;
		private Menu _menu;
		private Level _level;

		public SceneLoader(LoadingCurtain curtain, ICoroutineRunner coroutineRunner, LevelCreator levelCreator, MenuCreator menuCreator)
		{
			_curtain = curtain;
			_coroutineRunner = coroutineRunner;
			_levelCreator = levelCreator;
			_menuCreator = menuCreator;
		}

		public IEnumerator LoadMenuCoroutine()
		{
			_curtain.Show();

			if (_level is not null)
				_level.Exited -= LoadMenu;

			var operation = SceneManager.LoadSceneAsync(MenuSceneName);

			while (!operation.isDone)
				yield return null;

			_menu = _menuCreator.Create();

			_menu.Exited += LoadLevel;

			_curtain.Hide();
		}

		public IEnumerator LoadLevelCoroutine(LevelConfig levelConfig)
		{
			_curtain.Show();

			if (_menu is not null)
				_menu.Exited -= LoadLevel;

			var operation = SceneManager.LoadSceneAsync(LevelSceneName);

			while (!operation.isDone)
				yield return null;

			_level = _levelCreator.Create(levelConfig.RowsCount, levelConfig.RowsCount);

			_level.Exited += LoadMenu;

			_curtain.Hide();
		}

		public void LoadMenu()
		{
			if (_coroutine is not null)
				_coroutineRunner.StopCoroutine(_coroutine);

			_coroutine = _coroutineRunner.StartCoroutine(LoadMenuCoroutine());
		}

		public void LoadLevel(LevelConfig level)
		{
			if (_coroutine is not null)
				_coroutineRunner.StopCoroutine(_coroutine);

			_coroutine = _coroutineRunner.StartCoroutine(LoadLevelCoroutine(level));
		}
	}
}

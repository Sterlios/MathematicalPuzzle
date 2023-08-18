using UnityEngine;
using MathPuzzleLogic.Factory;
using UnityObjects.LevelObjects.Factories;
using MathPuzzleLogic.Control;
using UnityObjects.SceneLoading;
using UnityObjects.SceneLoading.Loading;

namespace UnityObjects.Scene.Bootstrap
{
	public class Bootstraper : MonoBehaviour, ICoroutineRunner, ISceneLoader
	{
		private SceneLoader _sceneLoader;
		private Controller _controller;
		private MathPuzzleCreator _mathPuzzleCreator;
		private MechanismCreator _mechanismCreator;
		private MenuCreator _menuCreator;

		private Coroutine _coroutine;

		private void Awake()
		{
			DontDestroyOnLoad(this);

			Curtain curtain = FindObjectOfType<Curtain>();
			_sceneLoader = new SceneLoader(curtain);

			_menuCreator = new MenuCreator();

			_mathPuzzleCreator = new MathPuzzleCreator();

			ControlMap controlMap = new ControlMap();
			_controller = new Controller(controlMap);

			WheelCreator wheelCreator = new WheelCreator();
			CellCreator cellCreator = new CellCreator();
			ResultCellCreator resultCellCreator = new ResultCellCreator();

			_mechanismCreator = new MechanismCreator(wheelCreator, cellCreator, resultCellCreator);

			LoadMenu();
		}

		public void LoadMenu()
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(_sceneLoader.LoadMenu(this, _menuCreator));
		}

		public void LoadLevel(ScriptableObjects.Level level)
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(_sceneLoader.LoadLevel(level, this, _controller, _mathPuzzleCreator, _mechanismCreator));
		}
	}

	public interface ISceneLoader
	{
		void LoadMenu();
		void LoadLevel(ScriptableObjects.Level level);
	}
}


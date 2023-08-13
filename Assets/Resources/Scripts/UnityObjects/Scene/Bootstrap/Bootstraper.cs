using UnityEngine;
using MathPuzzleLogic.Factory;
using UnityObjects.LevelObjects.Factories;
using MathPuzzleLogic.Control;
using System;
using UnityObjects.SceneLoading;
using UnityObjects.SceneLoading.Loading;

namespace UnityObjects.Scene.Bootstrap
{
	public class Bootstraper : MonoBehaviour, ICoroutineRunner
	{
		private SceneLoader _sceneLoader;
		private Controller _controller;
		private MathPuzzleCreator _mathPuzzleCreator;
		private MechanismCreator _mechanismCreator;

		private void Awake()
		{
			DontDestroyOnLoad(this);

			Curtain curtain = FindObjectOfType<Curtain>();
			_sceneLoader = new SceneLoader(curtain);

			_mathPuzzleCreator = new MathPuzzleCreator();

			ControlMap controlMap = new ControlMap();
			_controller = new Controller(controlMap);

			WheelCreator wheelCreator = new WheelCreator();
			CellCreator cellCreator = new CellCreator();
			ResultCellCreator resultCellCreator = new ResultCellCreator();

			_mechanismCreator = new MechanismCreator(wheelCreator, cellCreator, resultCellCreator);

			LoadScene("Menu");
		}

		public void LoadScene(string sceneName)
		{
			_sceneLoader.Load(sceneName);
		}

		public void LoadScene(string sceneName, int wheelsCount, int raysCount)
		{
			_sceneLoader.Load(sceneName, wheelsCount, raysCount, _controller, _mathPuzzleCreator, _mechanismCreator);
		}
	}
}


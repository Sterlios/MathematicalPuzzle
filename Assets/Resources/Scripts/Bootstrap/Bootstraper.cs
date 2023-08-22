using UnityEngine;
using MathPuzzleLogic.Factory;
using MathPuzzleLogic.Control;
using SceneLoading;
using Curtain;
using Curtain.Factories;
using MenuScene.Factories;
using LevelScene.Factories;

namespace Bootstrap
{
	public class Bootstraper : MonoBehaviour, ICoroutineRunner
	{
		private SceneLoader _sceneLoader;

		private void Awake()
		{
			DontDestroyOnLoad(this);

			LoadingCurtain curtain = new CurtainCreator().Create();

			MathPuzzleCreator mathPuzzleCreator = new MathPuzzleCreator();

			ControlMap controlMap = new ControlMap();
			Controller controller = new Controller(controlMap);

			WheelCreator wheelCreator = new WheelCreator();
			CellCreator cellCreator = new CellCreator();
			ResultCellCreator resultCellCreator = new ResultCellCreator();

			MechanismCreator mechanismCreator = new MechanismCreator(wheelCreator, cellCreator, resultCellCreator);

			MenuCreator menuCreator = new MenuCreator();
			LevelCreator levelCreator = new LevelCreator(mathPuzzleCreator, mechanismCreator, controller);

			_sceneLoader = new SceneLoader(curtain, this, levelCreator, menuCreator);
		}

		private void Start()
		{
			_sceneLoader.LoadMenu();
		}
	}
}


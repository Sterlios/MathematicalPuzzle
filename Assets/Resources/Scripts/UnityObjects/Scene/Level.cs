using Extention.UnityExtention;
using MathPuzzleLogic.Control;
using MathPuzzleLogic.Logic;
using UnityEngine;
using UnityObjects.LevelObjects.Factories;
using UnityObjects.LevelObjects.Objects;
using UnityObjects.LevelObjects.UI;
using UnityObjects.Scene.Bootstrap;
using UnityObjects.Scene.Panels;

namespace UnityObjects.Scene
{
	public class Level : MonoBehaviour
	{
		private MechanismCreator _mechanismCreator;

		private ScriptableObjects.LevelConfig _levelConfig;
		private Controller _puzzleController;
		private WinPanel _winPanel;
		private MathPuzzle _puzzle;
		private ISceneLoader _sceneLoader;
		private PuzzleControl _puzzleControl;

		private BackMenuButton[] _backMenuButtons;

		private void Awake()
		{
			_backMenuButtons = FindObjectsOfType<BackMenuButton>();

			_puzzleControl = FindObjectOfType<PuzzleControl>();

			_winPanel = FindObjectOfType<WinPanel>();
			_winPanel.gameObject.Deactivate();
			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();

			_ = _mechanismCreator.Create(spawnPoint, _puzzle);

			_puzzleController.Initialize(_puzzle);
			_puzzle.Resolved += Finish;
		}

		private void OnDisable()
		{
			if (_puzzle is null)
				return; 

			_puzzle.Resolved -= Finish;
		}

		public void Initialize(
			ScriptableObjects.LevelConfig levelConfig,
			ISceneLoader sceneLoader,
			Controller puzzleController,
			MechanismCreator mechanismCreator)
		{
			foreach (BackMenuButton backMenuButton in _backMenuButtons)
				backMenuButton.Initialize(sceneLoader);

			_levelConfig = levelConfig;
			_sceneLoader = sceneLoader;
			_puzzle = levelConfig.Puzzle;
			_puzzleController = puzzleController;
			_mechanismCreator = mechanismCreator;
			_puzzleControl.Initialize(_puzzle);

			_levelConfig.Play();

			gameObject.Activate();
		}

		public void MoveToMenu()
		{
			_sceneLoader.LoadMenu();
		}

		private void Finish()
		{
			_levelConfig.Finish();
			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}
	}
}
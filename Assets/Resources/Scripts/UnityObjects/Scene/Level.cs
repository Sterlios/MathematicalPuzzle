using Extention.UnityExtention;
using MathPuzzleLogic.Control;
using MathPuzzleLogic.Logic;
using UnityEngine;
using UnityObjects.LevelObjects.Factories;
using UnityObjects.LevelObjects.Objects;
using UnityObjects.Scene.Bootstrap;
using UnityObjects.Scene.Panels;

namespace UnityObjects.Scene
{
	public class Level : MonoBehaviour
	{
		private MechanismCreator _mechanismCreator;

		private Controller _puzzleController;
		private WinPanel _winPanel;
		private MathPuzzle _puzzle;
		private ISceneLoader _sceneLoader;

		private void Awake()
		{
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
			ISceneLoader sceneLoader,
			MathPuzzle puzzle,
			Controller puzzleController,
			MechanismCreator mechanismCreator)
		{
			_sceneLoader = sceneLoader;
			_puzzle = puzzle;
			_puzzleController = puzzleController;
			_mechanismCreator = mechanismCreator;

			gameObject.Activate();
		}

		public void MoveToMenu()
		{
			_sceneLoader.LoadMenu();
		}

		private void Finish()
		{
			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}
	}
}
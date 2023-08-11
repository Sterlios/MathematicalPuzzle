using Extention.UnityExtention;
using MathPuzzleLogic.Control;
using MathPuzzleLogic.Logic;
using UnityEngine;
using UnityObjects.LevelObjects.Factories;
using UnityObjects.LevelObjects.Objects;
using UnityObjects.Scene.Panels;

namespace UnityObjects.Scene
{
	public class Level : MonoBehaviour
	{
		private static readonly System.Random _random = new System.Random();

		private MechanismCreator _mechanismCreator;

		private Controller _puzzleController;
		private WinPanel _winPanel;
		private MathPuzzle _puzzle;

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
			_puzzle.Resolved -= Finish;
		}

		public void Initialize(
			MathPuzzle puzzle,
			Controller puzzleController,
			MechanismCreator mechanismCreator)
		{
			_puzzle = puzzle;
			_puzzleController = puzzleController;
			_mechanismCreator = mechanismCreator;

			gameObject.Activate();
		}

		private void Finish()
		{
			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}
	}
}
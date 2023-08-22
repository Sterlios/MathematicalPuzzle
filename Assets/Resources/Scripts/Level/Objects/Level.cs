using Extention.UnityExtention;
using LevelScene.Factories;
using LevelScene.UI;
using MathPuzzleLogic.Control;
using MathPuzzleLogic.Logic;
using System;
using UnityEngine;

namespace LevelScene.Objects
{
	public class Level : MonoBehaviour
	{
		private MechanismCreator _mechanismCreator;

		private Controller _puzzleController;
		private WinPanel _winPanel;
		private MathPuzzle _puzzle;
		private PuzzleControl _puzzleControl;

		private BackMenuButton[] _backMenuButtons;

		public event Action Exited;

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

			foreach (BackMenuButton backMenuButton in _backMenuButtons)
				backMenuButton.Clicked += MoveToMenu;

			_mechanismCreator.Create(spawnPoint, _puzzle);

			_puzzleController.Initialize(_puzzle);
			_puzzle.Resolved += Finish;
		}

		private void OnDisable()
		{
			foreach (BackMenuButton backMenuButton in _backMenuButtons)
				backMenuButton.Clicked -= MoveToMenu;

			if (_puzzle is null)
				return;

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
			_puzzleControl.Initialize(_puzzle);

			gameObject.Activate();
		}

		public void MoveToMenu()
		{
			Exited?.Invoke();
		}

		private void Finish()
		{
			Save();
			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}

		private void Save()
		{
			PlayerPrefs.SetInt(_puzzle.SaverKey, (int)LevelStatus.Done);
			PlayerPrefs.Save();
		}
	}
}
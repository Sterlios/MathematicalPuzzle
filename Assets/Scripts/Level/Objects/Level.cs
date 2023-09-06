using DataSource;
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

		private UICanvas _uICanvas;
		private Controller _puzzleController;
		private MathPuzzle _puzzle;
		private ISaver _saver;

		public event Action Exited;

		private void Awake()
		{
			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>(); //TODO Use Other Method

			foreach (BackMenuButton backMenuButton in _uICanvas.BackMenuButtons)
				backMenuButton.Clicked += MoveToMenu;

			_mechanismCreator.Create(spawnPoint, _puzzle);

			_puzzleController.Initialize(_puzzle);
			_puzzle.Resolved += Finish;

			_uICanvas.FinishPanel.DeactivateAllPanels();
		}

		private void OnDisable()
		{
			foreach (BackMenuButton backMenuButton in _uICanvas.BackMenuButtons)
				backMenuButton.Clicked -= MoveToMenu;

			if (_puzzle is null)
				return;

			_puzzle.Resolved -= Finish;
		}

		public void Initialize(
			ISaver saver,
			MathPuzzle puzzle,
			Controller puzzleController,
			MechanismCreator mechanismCreator,
			UICreator uICreator
			)
		{
			_uICanvas = uICreator.Create();
			_saver = saver;
			_puzzle = puzzle;
			_puzzleController = puzzleController;
			_mechanismCreator = mechanismCreator;
			_uICanvas.PuzzleControl.Initialize(_puzzle);
			
			gameObject.Activate();
		}

		public void MoveToMenu()
		{
			Exited?.Invoke();
		}

		private void Finish()
		{
			_saver.Save(_puzzle.SaverKey, LevelStatus.Done);

			_uICanvas.FinishPanel.ActivateWinPanel();
		}
	}
}
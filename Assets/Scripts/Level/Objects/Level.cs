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

		private Controller _puzzleController;
		private FinishPanel _finishPanel;
		private MathPuzzle _puzzle;
		private PuzzleControl _puzzleControl;
		private ISaver _saver;

		private BackMenuButton[] _backMenuButtons;

		public event Action Exited;

		private void Awake()
		{
			gameObject.Deactivate();
		}

		private void OnEnable()
		{
			SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>(); //TODO Use Other Method

			foreach (BackMenuButton backMenuButton in _backMenuButtons)
				backMenuButton.Clicked += MoveToMenu;

			_mechanismCreator.Create(spawnPoint, _puzzle);

			_puzzleController.Initialize(_puzzle);
			_puzzle.Resolved += Finish;

			_finishPanel.DeactivateAllPanels();
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
			ISaver saver,
			MathPuzzle puzzle,
			Controller puzzleController,
			MechanismCreator mechanismCreator,
			UICreator uICreator
			)
		{
			UICanvas uICanvas = uICreator.Create();
			_saver = saver;
			_puzzle = puzzle;
			_puzzleController = puzzleController;
			_mechanismCreator = mechanismCreator;
			_puzzleControl.Initialize(_puzzle);
			
			_backMenuButtons = uICanvas.GetBackMenuButtons();
			_puzzleControl = uICanvas.GetPuzzleControl();
			_finishPanel = uICanvas.GetFinishPanel();

			gameObject.Activate();
		}

		public void MoveToMenu()
		{
			Exited?.Invoke();
		}

		private void Finish()
		{
			_saver.Save(_puzzle.SaverKey, LevelStatus.Done);
			
			_finishPanel.ActivateWinPanel();
		}
	}
}
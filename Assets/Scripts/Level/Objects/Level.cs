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
		private FinishPanel _finishPanel;
		private MathPuzzle _puzzle;
		private PuzzleControl _puzzleControl;
		private ISaver _saver;

		private BackMenuButton[] _backMenuButtons;

		public event Action Exited;

		private void Awake()
		{
			_backMenuButtons = FindObjectsOfType<BackMenuButton>(); //TODO Use Other Method

			_puzzleControl = FindObjectOfType<PuzzleControl>(); //TODO Use Other Method

			_finishPanel = FindObjectOfType<FinishPanel>(); //TODO Use Other Method
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
			_uICanvas = uICreator.Create();
			_saver = saver;
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
			_saver.Save(_puzzle.SaverKey, LevelStatus.Done);
			
			_finishPanel.ActivateWinPanel();
		}
	}
}
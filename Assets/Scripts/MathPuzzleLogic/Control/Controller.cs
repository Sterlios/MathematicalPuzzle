using MathPuzzleLogic.Logic;
using System;

namespace MathPuzzleLogic.Control
{
	public class Controller: IDisposable
	{
		private readonly ControlMap _puzzleControl;
		private MathPuzzle _puzzle;

		public Controller(ControlMap puzzleControl)
		{
			_puzzleControl = puzzleControl;
		}

		public void Initialize(MathPuzzle puzzle)
		{
			_puzzle = puzzle;
			
			_puzzleControl.Player.Enable();
			_puzzleControl.Player.MoveLeft.performed += context => _puzzle.MoveLeft();
			_puzzleControl.Player.MoveRight.performed += context => _puzzle.MoveRight();
			_puzzleControl.Player.ShiftUp.performed += context => _puzzle.ShiftUp();
			_puzzleControl.Player.ShiftDown.performed += context => _puzzle.ShiftDown();
		}

		public void Dispose()
		{
			_puzzleControl.Player.MoveLeft.performed -= context => _puzzle.MoveLeft();
			_puzzleControl.Player.MoveRight.performed -= context => _puzzle.MoveRight();
			_puzzleControl.Player.ShiftUp.performed -= context => _puzzle.ShiftUp();
			_puzzleControl.Player.ShiftDown.performed -= context => _puzzle.ShiftDown();

			_puzzleControl.Player.Disable();
		}
	}
}

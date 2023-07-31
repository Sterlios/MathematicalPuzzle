using System;
using UnityEngine;

namespace CookingNumbers
{
	public class MathPuzzleController: IDisposable
	{
		private readonly MapControl _puzzleControl;
		private MathPuzzle _puzzle;

		public MathPuzzleController(MapControl puzzleControl)
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

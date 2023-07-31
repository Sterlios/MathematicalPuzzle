using System;
using UnityEngine;

namespace CookingNumbers
{
	public class MathPazzleController: IDisposable
	{
		private readonly MapControl _mapControl;
		private MathPazzle _map;

		public MathPazzleController(MapControl mapControl)
		{
			_mapControl = mapControl;
		}

		public void Initialize(MathPazzle map)
		{
			_map = map;
			
			_mapControl.Player.Enable();
			_mapControl.Player.MoveLeft.performed += context => _map.MoveLeft();
			_mapControl.Player.MoveRight.performed += context => _map.MoveRight();
			_mapControl.Player.ShiftUp.performed += context => _map.ShiftUp();
			_mapControl.Player.ShiftDown.performed += context => _map.ShiftDown();
		}

		public void Dispose()
		{
			_mapControl.Player.MoveLeft.performed -= context => _map.MoveLeft();
			_mapControl.Player.MoveRight.performed -= context => _map.MoveRight();
			_mapControl.Player.ShiftUp.performed -= context => _map.ShiftUp();
			_mapControl.Player.ShiftDown.performed -= context => _map.ShiftDown();

			_mapControl.Player.Disable();
		}
	}
}

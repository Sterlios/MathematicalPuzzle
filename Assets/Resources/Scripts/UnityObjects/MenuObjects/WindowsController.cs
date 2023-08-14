using System;
using UnityEngine;

namespace UnityObjects
{
    public class WindowsController : MonoBehaviour
    {
        private Window[] _windows;

		private void Start()
		{
			_windows = GetComponentsInChildren<Window>();

			foreach (Window window in _windows)
				window.Close();
		}

		public void Open(Window target)
		{
			foreach(Window window in _windows)
			{
				if (window == target)
					window.Open();
				else
					window.Close();
			}
		}
	}
}

using System;

namespace CookingNumbers
{
	internal abstract class Transition
	{
		private readonly State _nextState;

		private bool _isOpen;

		public State NextState => _isOpen ? _nextState : null;

		protected Transition(State nextState)
		{
			if (nextState == null)
				throw new ArgumentNullException("Next state cannot be null.");

			_nextState = nextState;
		}

		protected void Open()
		{
			_isOpen = true;
		}

		protected void Close()
		{
			_isOpen = false;
		}
	}
}

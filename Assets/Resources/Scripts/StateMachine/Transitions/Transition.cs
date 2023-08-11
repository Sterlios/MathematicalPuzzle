using StateMachine.States;
using System;

namespace StateMachine.Transitions
{
	public abstract class Transition
	{
		private State _nextState;

		private bool _isOpen;

		public State NextState => _isOpen ? _nextState : null;

		public void Initialize(State nextState)
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

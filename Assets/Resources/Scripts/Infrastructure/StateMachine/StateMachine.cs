using System;

namespace CookingNumbers
{
	internal class StateMachine
	{
		private readonly State _firstState;
		private State _currentState;

		public StateMachine(State firstState)
		{
			if (_firstState == null)
				throw new ArgumentNullException("First state cannot be null.");

			_firstState = firstState;
		}

		public void Run()
		{
			Transit(_firstState);
		}

		private void Transit(State nextState)
		{
			if (nextState == null)
				return;

			if (_currentState != null)
				_currentState.Transited -= Transit;

			_currentState = nextState;
			_currentState.Enter();
			_currentState.Transited += Transit;
		}
	}
}

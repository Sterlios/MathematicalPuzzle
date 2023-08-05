using System;
using System.Collections;

namespace StateMachine
{
	public class BaseStateMachine
	{
		private readonly State _firstState;
		private State _currentState;

		public BaseStateMachine(State firstState)
		{
			if (firstState == null)
				throw new ArgumentNullException("First state cannot be null.");

			_firstState = firstState;
		}

		public IEnumerator Update()
		{
			Run(); 

			while (_currentState is not null)
			{
				Transit(_currentState.NextState);

				yield return null;
			}
		}

		private void Run()
		{
			Transit(_firstState);
		}

		private void Transit(State nextState)
		{
			if (nextState == null)
				return;

			_currentState?.Stop();
			_currentState = nextState;
			_currentState.Start();
		}
	}
}

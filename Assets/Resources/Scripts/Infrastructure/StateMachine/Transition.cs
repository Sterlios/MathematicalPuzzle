using System;

namespace CookingNumbers
{
	internal abstract class Transition
	{
		private readonly State _nextState;

		public event Action<State> Opened;

		protected Transition(State nextState)
		{
			if (nextState == null)
				throw new ArgumentNullException("Next state cannot be null.");

			_nextState = nextState;
		}

		protected void Open()
		{
			Opened?.Invoke(_nextState);
		}
	}
}

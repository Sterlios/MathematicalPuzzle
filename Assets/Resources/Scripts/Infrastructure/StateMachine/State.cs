using System;
using System.Collections.Generic;
using System.Linq;

namespace CookingNumbers
{
	internal abstract class State
	{
		private readonly List<Transition> _transitions;

		public event Action<State> Transited;
		
		public State(params Transition[] transitions)
		{
			_transitions = transitions.ToList();
		}

		public void Enter()
		{
			foreach (Transition transition in _transitions)
				transition.Opened += Exit;
		}

		private void Exit(State nextState)
		{
			if (nextState == null)
				return;

			foreach (Transition transition in _transitions)
				transition.Opened -= Exit;

			Transited?.Invoke(nextState);
		}
	}
}

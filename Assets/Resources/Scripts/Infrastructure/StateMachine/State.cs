using System.Collections.Generic;
using System.Linq;

namespace CookingNumbers
{
	internal abstract class State
	{
		private readonly List<Transition> _transitions;

		public State NextState {
			get
			{
				foreach (Transition transition in _transitions)
				{
					State nextState = transition.NextState;

					if (nextState is not null)
						return nextState;
				}

				return null;
			}
		}

		public State(params Transition[] transitions)
		{
			_transitions = transitions.ToList();
		}

		public abstract void Start();

		public abstract void Stop();
	}
}

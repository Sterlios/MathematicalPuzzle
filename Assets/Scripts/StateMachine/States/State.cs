//using StateMachine.Transitions;
//using System.Collections.Generic;
//using System.Linq;

//namespace StateMachine.States
//{
//	public abstract class State
//	{
//		private List<Transition> _transitions;

//		public State NextState {
//			get
//			{
//				foreach (Transition transition in _transitions)
//				{
//					State nextState = transition.Transit();

//					if (nextState is not null)
//						return nextState;
//				}

//				return null;
//			}
//		}

//		public void Initialize(params Transition[] transitions)
//		{
//			_transitions = transitions.ToList();
//		}

//		public abstract void Start();

//		public abstract void Stop();
//	}
//}

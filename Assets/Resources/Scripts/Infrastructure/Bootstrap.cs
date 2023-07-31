using UnityEngine;

namespace CookingNumbers
{
	public class Bootstrap : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(this);
			StateMachine game = new GameStateMachineCreator().Create();
			game.Run();
		}
	}

	internal class BootstrapState : State
	{
		public BootstrapState(params Transition[] transitions) : base(transitions)
		{
		}
	}

	internal class GameStateMachineCreator
	{
		public StateMachine Create()
		{
			BootstrapState bootstrapState = new BootstrapState();

			StateMachine game = new StateMachine(bootstrapState);

			return game;
		}
	}
}

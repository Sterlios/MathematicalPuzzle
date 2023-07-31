namespace CookingNumbers
{
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

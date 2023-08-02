namespace CookingNumbers
{
	internal class GameStateMachineCreator
	{
		public StateMachine Create(ICoroutineRunner coroutineRunner)
		{
			BootstrapState bootstrapState = new BootstrapState();

			StateMachine game = new StateMachine(coroutineRunner, bootstrapState);

			return game;
		}
	}
}

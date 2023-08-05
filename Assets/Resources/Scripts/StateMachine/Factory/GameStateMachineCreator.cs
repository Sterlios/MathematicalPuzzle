namespace StateMachine.Factory
{
	public class GameStateMachineCreator
	{
		public BaseStateMachine Create()
		{
			BootstrapState bootstrapState = new BootstrapState();

			BaseStateMachine game = new BaseStateMachine(bootstrapState);

			return game;
		}
	}
}

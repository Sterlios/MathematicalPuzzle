using StateMachine.States;
using StateMachine.Transitions;

namespace StateMachine.Factory
{
	public class GameStateMachineCreator
	{
		public BaseStateMachine Create()
		{
			BootstrapState bootstrapState = new BootstrapState();
			MainMenuState mainMenuState = new MainMenuState();

			MainMenuTransition mainMenuTransition = new MainMenuTransition();

			bootstrapState.Initialize(mainMenuTransition);
			mainMenuTransition.Initialize(mainMenuState);

			BaseStateMachine game = new BaseStateMachine(bootstrapState);

			return game;
		}
	}
}

//using SceneLoading;
//using StateMachine.States;
//using StateMachine.Transitions;

//namespace StateMachine.Factory
//{
//	public class GameStateMachineCreator
//	{
//		public BaseStateMachine Create(SceneLoader sceneLoader)
//		{
//			BootstrapState bootstrapState = new BootstrapState();
//			MainMenuState mainMenuState = new MainMenuState();

//			MainMenuTransition mainMenuTransition = new MainMenuTransition(sceneLoader);

//			bootstrapState.Initialize(mainMenuTransition);
//			mainMenuTransition.Initialize(mainMenuState);

//			BaseStateMachine game = new BaseStateMachine(bootstrapState);

//			return game;
//		}
//	}
//}

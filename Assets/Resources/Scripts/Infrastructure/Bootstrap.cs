using UnityEngine;

namespace CookingNumbers
{
	public class Bootstrap : MonoBehaviour, ICoroutineRunner
	{
		private void Awake()
		{
			DontDestroyOnLoad(this);

			StateMachine game = new GameStateMachineCreator().Create(this);
			game.Run();
		}
	}
}

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
}

using UnityEngine;
using StateMachine;
using StateMachine.Factory;

namespace UnityObjects.Scene.Bootstrap
{
	public class Bootstraper : MonoBehaviour, ICoroutineRunner
	{
		private Coroutine _coroutine;
		private BaseStateMachine _game;

		private void Awake()
		{
			DontDestroyOnLoad(this);

			_game = new GameStateMachineCreator().Create();
		}

		private void OnEnable()
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);

			StartCoroutine(_game.Update());
		}
	}
}

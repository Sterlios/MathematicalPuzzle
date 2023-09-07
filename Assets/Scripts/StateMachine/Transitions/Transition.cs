//using SceneLoading;
//using StateMachine.States;
//using System;

//namespace StateMachine.Transitions
//{
//	public abstract class Transition
//	{
//		private readonly SceneLoader _sceneLoader;
//		private readonly string _sceneName;

//		private State _nextState;
//		private bool _isOpen;

//		public Transition(SceneLoader sceneLoader, string sceneName)
//		{
//			_sceneLoader = sceneLoader;
//			_sceneName = sceneName;
//		}

//		public void Initialize(State nextState)
//		{
//			if (nextState == null)
//				throw new ArgumentNullException("Next state cannot be null.");

//			_nextState = nextState;
//		}

//		public State Transit()
//		{
//			if (!_isOpen)
//				return null;

//			_sceneLoader.Load(_sceneName);

//			return _nextState;
//		}

//		public void Open()
//		{
//			_isOpen = true;
//		}

//		public void Close()
//		{
//			_isOpen = false;
//		}
//	}
//}

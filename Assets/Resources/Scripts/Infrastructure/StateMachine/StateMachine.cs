using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CookingNumbers
{
	internal class StateMachine
	{
		private readonly ICoroutineRunner _coroutineRunner;
		private readonly State _firstState;
		private State _currentState;

		private Coroutine _coroutine;

		public StateMachine(ICoroutineRunner coroutineRunner, State firstState)
		{
			if (_firstState == null)
				throw new ArgumentNullException("First state cannot be null.");
			_coroutineRunner = coroutineRunner;
			_firstState = firstState;
		}

		public void Run()
		{
			Transit(_firstState);

			_coroutine = _coroutineRunner.StartCoroutine(Update());
		}

		public void Stop()
		{
			_coroutineRunner.StopCoroutine(_coroutine);
		}

		private IEnumerator Update()
		{
			while (_currentState is not null)
			{
				Transit(_currentState.NextState);

				yield return null;
			}
		}

		private void Transit(State nextState)
		{
			if (nextState == null)
				return;

			_currentState?.Stop();
			_currentState = nextState;
			_currentState.Start();
		}
	}
}

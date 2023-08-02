
using System.Collections;
using UnityEngine;

namespace CookingNumbers
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator routine);
		void StopCoroutine(Coroutine coroutine);
	}
}

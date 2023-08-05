
using System.Collections;
using UnityEngine;

namespace UnityObjects.Scene.Bootstrap
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator routine);
		void StopCoroutine(Coroutine coroutine);
	}
}

using System.Collections;
using UnityEngine;

namespace SceneLoading
{
	public interface ICoroutineRunner
	{
		void StopCoroutine(Coroutine routine);
		Coroutine StartCoroutine(IEnumerator job);
	}
}

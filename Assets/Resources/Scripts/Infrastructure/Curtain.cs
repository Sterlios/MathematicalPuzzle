
using System.Collections;
using UnityEngine;

namespace CookingNumbers
{
	[RequireComponent(typeof(Renderer))]
	internal class Curtain : MonoBehaviour, ICurtain
 	{
		[SerializeField] private float _fadeInSpeed;
		
		private Coroutine _coroutine;
		private Material _material;

		private void Awake()
		{
			_material = GetComponent<Renderer>().material;
		}

		public void Show()
		{
			gameObject.Activate();

			_material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 1);
		}

		public void Hide()
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(FadeIn());
		}

		private IEnumerator FadeIn()
		{
			Color target = new Color(_material.color.r, _material.color.g, _material.color.b, 0);

			while (_material.color.a > target.a)
			{
				float newAlpha = _material.color.a - _fadeInSpeed * Time.deltaTime;

				_material.color = new Color(_material.color.r, _material.color.g, _material.color.b, newAlpha);

				yield return null;
			}
		}
	}
}

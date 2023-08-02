
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CookingNumbers
{
	internal class Curtain : MonoBehaviour, ICurtain
 	{
		[SerializeField] private float _fadeInSpeed;
		
		private Coroutine _coroutine;
		private Image _image;

		private void Awake()
		{
			DontDestroyOnLoad(this);

			_image = GetComponentInChildren<Image>();
		}

		public void Show()
		{
			gameObject.Activate();

			_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
		}

		public void Hide()
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(FadeIn());
		}

		private IEnumerator FadeIn()
		{
			float targetAlpha = 0;

			while (_image.color.a > targetAlpha)
			{
				float newAlpha = _image.color.a - _fadeInSpeed * Time.deltaTime;

				_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, newAlpha);

				yield return null;
			}
		}
	}
}

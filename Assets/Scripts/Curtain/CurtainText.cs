using System.Collections;
using TMPro;
using UnityEngine;

namespace Curtain
{
	[RequireComponent(typeof(TMP_Text))]
	public class CurtainText : MonoBehaviour
	{
		[SerializeField] private float _blinkingSpeed;

		private Coroutine _coroutine;

		private TMP_Text _text;

		private void Awake()
		{
			_text = GetComponent<TMP_Text>();
		}

		private void OnEnable()
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(Blink());
		}

		private void OnDisable()
		{
			StopCoroutine(_coroutine);
		}

		public IEnumerator Blink()
		{
			float minAlpha = 0.1f;
			float maxAlpha = 1f;

			while (enabled)
			{
				while (_text.color.a > minAlpha)
				{
					ChengeColor(-_blinkingSpeed);
					yield return null;
				}

				while (_text.color.a < maxAlpha)
				{
					ChengeColor(_blinkingSpeed);
					yield return null;
				}
			}
		}

		private void ChengeColor(float blinkingSpeed)
		{
			float newAlpha = _text.color.a + blinkingSpeed * Time.deltaTime;

			_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, newAlpha);
		}
	}
}
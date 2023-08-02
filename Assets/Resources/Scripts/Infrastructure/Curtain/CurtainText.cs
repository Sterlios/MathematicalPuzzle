using System.Collections;
using TMPro;
using UnityEngine;

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
		while (enabled)
		{
			while (_text.color.a > 0)
			{
				ChengeColor(-_blinkingSpeed);
				yield return null;
			}

			while (_text.color.a < 1)
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

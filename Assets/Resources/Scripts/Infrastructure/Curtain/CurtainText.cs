using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class CurtainText : MonoBehaviour
{
	[SerializeField] private float _blinkingSpeed;

	private TMP_Text _text;

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		Blink();
	}

	private void Blink()
	{
		while (enabled)
		{
			FadeIn();
			Appear();
		}
	}

	private void Appear()
	{
		while (_text.color.a < 1)
			ChengeColor(_blinkingSpeed);
	}

	private void FadeIn()
	{
		while (_text.color.a > 0)
			ChengeColor(-_blinkingSpeed);
	}

	private void ChengeColor(float blinkingSpeed)
	{
		float newAlpha = _text.color.a + blinkingSpeed * Time.deltaTime;

		_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, newAlpha);
	}
}

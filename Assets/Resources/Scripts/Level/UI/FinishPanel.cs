using Extention.UnityExtention;
using System.Collections;
using UnityEngine;

namespace LevelScene.UI
{
	public class FinishPanel : MonoBehaviour
	{
		[SerializeField] private WinPanel _winPanel;
		private Coroutine _coroutine;

		private void Start()
		{
			//DeactivateAllPanels();
		}

		public void ActivateWinPanel()
		{
			if (_coroutine is not null)
				StopCoroutine(_coroutine);

			_coroutine = StartCoroutine(ShowWinPanel());
		}

		public void DeactivateAllPanels()
		{
			_winPanel.gameObject.Deactivate();
		}

		private IEnumerator ShowWinPanel()
		{
			float delaySeconds = 1f;
			float timer = 0;

			while (timer < delaySeconds)
			{
				timer += Time.deltaTime;
				yield return null;
			}


			Time.timeScale = 0;
			_winPanel.gameObject.Activate();
		}
	}
}

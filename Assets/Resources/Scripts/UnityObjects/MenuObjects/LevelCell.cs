
using UnityEngine;
using UnityObjects.Scene.Bootstrap;

namespace UnityObjects
{
	public class LevelCell : MonoBehaviour
	{
		[SerializeField] private int _wheelsCount;
		[SerializeField] private int _raysCount;
		[SerializeField] private LevelStatus _status;

		[SerializeField] private ISceneLoader _sceneLoader;

		public LevelStatus Status => _status;

		public void Initialize(ISceneLoader sceneLoader)
		{
			_sceneLoader = sceneLoader;
		}

		public void OnButtonClick()
		{
			if (_status == LevelStatus.Lock)
				return;

			_sceneLoader.LoadLevel(_wheelsCount, _raysCount);
		}

		public void Open()
		{
			_status = LevelStatus.NotPlaying;
		}

		public void Play()
		{
			_status = LevelStatus.NotDone;
		}

		public void Finish()
		{
			_status = LevelStatus.Done;
		}
	}
}


using UnityEngine;

namespace Curtain.Factories
{
	public class CurtainCreator
	{
		private readonly string _curtainPath = "Prefabs/Curtain";

		public LoadingCurtain Create()
		{
			LoadingCurtain curtainPrefab = Resources.Load<LoadingCurtain>(_curtainPath);
			LoadingCurtain curtain = Object.Instantiate(curtainPrefab);

			return curtain;
		}
	}
}

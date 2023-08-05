using UnityEngine;

namespace Extention.UnityExtention
{
	public static class GameObjectExtention
	{
		public static void Activate(this GameObject gameObject) =>
			gameObject.SetActive(true);

		public static void Deactivate(this GameObject gameObject) =>
			gameObject.SetActive(false);
	}
}

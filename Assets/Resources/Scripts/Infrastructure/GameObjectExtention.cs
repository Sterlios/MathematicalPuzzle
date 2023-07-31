
using UnityEngine;

namespace CookingNumbers
{
	public static class GameObjectExtention
	{
		public static void Activate(this GameObject gameObject) =>
			gameObject.SetActive(true);

		public static void Deactivate(this GameObject gameObject) =>
			gameObject.SetActive(false);
	}
}

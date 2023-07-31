using UnityEngine;

public class Game : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(this);
	}
}

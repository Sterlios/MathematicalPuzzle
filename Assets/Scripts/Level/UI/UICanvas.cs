using LevelScene.UI;
using System;
using UnityEngine;

namespace LevelScene
{
	public class UICanvas : MonoBehaviour
	{
		internal BackMenuButton[] BackMenuButtons { get; private set; }
		internal PuzzleControl PuzzleControl { get; private set; }
		internal FinishPanel FinishPanel { get; private set; }

		private void Awake()
		{
			BackMenuButtons = GetComponentsInChildren<BackMenuButton>();
			PuzzleControl = GetComponentInChildren<PuzzleControl>();
			FinishPanel = GetComponentInChildren<FinishPanel>();
		}
	}
}

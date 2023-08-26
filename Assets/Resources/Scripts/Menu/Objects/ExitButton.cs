using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenuScene
{
    public class ExitButton : MonoBehaviour
    {
        public void Exit()
		{
            Application.Quit();
		}
    }
}

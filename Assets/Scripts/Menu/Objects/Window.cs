using Extention.UnityExtention;
using UnityEngine;

namespace MenuScene.Objects
{
    public class Window : MonoBehaviour
    {
        public void Open()
		{
            gameObject.Activate();
		}

        public void Close()
		{
            gameObject.Deactivate();
		}
    }
}

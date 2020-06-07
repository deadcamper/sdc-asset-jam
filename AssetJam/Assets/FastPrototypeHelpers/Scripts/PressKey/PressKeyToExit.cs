using UnityEngine;

namespace DHG.Helpers
{
    public class PressKeyToExit : MonoBehaviour
    {

        public KeyCode key = KeyCode.Escape;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(key))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
            }
        }
    }
}
using UnityEngine;

namespace DHG.Helpers
{
    public class PressKeyToPauseTime : MonoBehaviour
    {
        public KeyCode key = KeyCode.Pause;

        private float lastTimeScale = 0f;
        void Update()
        {
            if (Input.GetKeyDown(key))
            {
                if (Time.timeScale != 0)
                {
                    lastTimeScale = Time.timeScale;
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = lastTimeScale;
                }
            }
        }
    }
}

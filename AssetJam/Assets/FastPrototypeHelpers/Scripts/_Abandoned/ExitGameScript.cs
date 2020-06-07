using UnityEngine;

namespace DHG.Helpers
{


    [CreateAssetMenu(fileName = "ExitGameScript", menuName = "EventScript/ExitGame", order = 1)]
    public class ExitGameScript : CodeScript
    {
        public int number;
        public override void Invoke()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
          UnityEngine.Application.Quit();
#endif
        }

        public static void Stroke()
        {
        }

    }
}
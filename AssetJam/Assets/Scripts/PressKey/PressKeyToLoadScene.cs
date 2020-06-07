using UnityEngine;
using UnityEngine.SceneManagement;

namespace DHG.Helpers
{
    public class PressKeyToLoadScene : MonoBehaviour
    {
        public KeyCode key = KeyCode.Escape;
        public string sceneName;

        public bool isAdditive = false;

        void Update()
        {
            if (Input.GetKeyDown(key))
            {
                LoadSceneMode mode = isAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single;
                SceneManager.LoadScene(sceneName, mode);
            }
        }

    }

}
